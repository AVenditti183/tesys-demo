param location string = resourceGroup().location // default parameter

@allowed([
  'dev'
  'test'
  'prod'
])
param environment string // parameter

param sqlAdministratorLogin string
var sqlAdministratorPassword = json(loadTextContent('bicep_configuration/configuration.json')).sqlAdministratorPasswordGenerated
// @secure()
// param sqlAdministratorPassword string

@allowed([
  'Standard_LRS'
  'Standard_GRS'
])
param storageSku string = 'Standard_LRS'

// variables
var storageResourceName = 'stbicepsessiontea${environment}'
var planResourceName = 'plan-bicepsessiontea-${environment}'
var funcResourceName = 'func-bicepsessiontea-${environment}'
var sqlResourceName = 'sql-bicepsessiontea-${environment}'
var sqldbResourceName = 'sqldb-bicepsessiontea-${environment}'
var appiResourceName = 'appi-bicepsessiontea-${environment}'
var kvResourceName = 'kv-bicepsession-main-tea'

module monitoring 'modules/monitoring.bicep' = {
  name: 'monitoring'
  params: {
    location: location
    resourceName: appiResourceName
  }
}

module data 'modules/data.bicep' = {
  name: 'data'
  params: {
    location: location
    kvResourceName: kvResourceName
    sqlAdministratorLogin: sqlAdministratorLogin
    sqlAdministratorPassword: sqlAdministratorPassword
    sqlServerResourceName: sqlResourceName
    sqldbResourceName: sqldbResourceName
    storageResourceName: storageResourceName
    storageSku: storageSku
    environment: environment
  }
}

module backend 'modules/backend.bicep' = {
  name: 'backend'
  params: {
    location: location
    kvResourceName: kvResourceName
    appInsightsConnectionString: monitoring.outputs.connectionString
    appInsightsInstrumentationKey: monitoring.outputs.instrumentationKey
    dbConnectionStringSecretUri: data.outputs.dbConnectionStringSecretUri
    environment: environment
    funcResourceName: funcResourceName
    planResourceName: planResourceName
    storageAccountId: data.outputs.storageAccountId 
    storageAccountName: storageResourceName
  }
}
