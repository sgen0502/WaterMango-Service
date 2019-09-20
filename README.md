# Watermango_Service

## Some interesting project for TapMango
# Requirement

- .Net Core 2.2 SDK (Can be find [here](https://dotnet.microsoft.com/download))</br>
- Git 

# Steps to launch
```sh
# 1. Make directory and clone project
mkdir WaterMango
cd WaterMango
git clone https://github.com/sgen0502/WaterMango-Service.git
git clone https://github.com/sgen0502/WaterMango-UI.git

#################################################################################################
# Front end build is pre-included in static folder of Service. You can skip thi part if you wish.
# If you want to be sure that you have latest UI code, please follow step 2 and 3. 
# Otherwise, proceed to step 4. 
#################################################################################################

# 2. Restore UI packages and build
cd WaterMango-UI
yarn install
npm run build

# 3. Copy built files into Service project
del /S /Q ..\WaterMango_Service\static 
robocopy build\ ..\WaterMango_Service\static\
robocopy build\static ..\WaterMango_Service\static\ /S

# 4. Restore dotnet packages
cd ..\WaterMango-Service
dotnet restore
dotnet run

# 5. Open https://localhost:5001/static/index.html in browser
```
## Known Issue
If you get an error saying that certificate is not trusted, please execute cmd below.
```
dotnet dev-certs https --trust 
```