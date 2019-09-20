using System.Collections.Generic;
using System.Composition;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;

namespace WaterMango_Service.Services
{
    [Export]
    [Shared]
    public class RuleService
    {
        private readonly ICommunicationDao<RuleModel> _dao;

        [ImportingConstructor]
        public RuleService(ICommunicationDao<RuleModel> dao)
        {
            _dao = dao;
        }

        public IList<RuleModel> GetRules()
        {
            return _dao.FindAll();
        }
    }
}