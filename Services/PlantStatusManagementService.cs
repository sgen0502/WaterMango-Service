using System;
using System.Linq;
using System.Reactive.Linq;
using Microsoft.AspNetCore.SignalR;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Services
{
    public class PlantStatusManagementService
    {
        private static PlantStatusManagementService _instance;
        private readonly PlantService _plantService;
        private readonly RuleService _ruleService;
        private bool _isStarted = false;

        private PlantStatusManagementService(PlantService plantService, RuleService ruleService)
        {
            _plantService = plantService;
            _ruleService = ruleService;
        }

        public static PlantStatusManagementService GetInstance(PlantService plantService, RuleService ruleService)
        {
            return _instance ?? (_instance = new PlantStatusManagementService(plantService, ruleService));
        }

        public void StartManagement(IHubCallerClients clients)
        {
            if(_isStarted) return;
                
            var ruleModels = _ruleService.GetRules();
            
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Subscribe(async i =>
                {
                    var plantModels = _plantService.GetAllPlants();
                    foreach (var plant in plantModels)
                    {
                        var rule = ruleModels.FirstOrDefault(r => r.CurrentStatus == plant.Status);
                        var timeToCopare = (rule?.TimeCalcTarget == TimeTarget.LASTUPDATE)
                            ? plant.LastUpdate
                            : plant.LastWaterSession;
                        if (rule != null && DateTime.Compare(i.Timestamp.LocalDateTime, timeToCopare.Add(rule.Time)) > 0)
                        {
                            plant.LastUpdate = i.Timestamp.LocalDateTime;
                            plant.Status = rule.NextStatus;
                            _plantService.UpdatePlant(plant);
                            
                            await clients.All.SendAsync("StatusUpdate", plant.Id, plant.Status, plant.LastUpdate);
                        }
                    }
                });

            _isStarted = true;
        }
    }
}