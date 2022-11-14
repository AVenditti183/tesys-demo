resource st 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: 'stbicepsessionteacher'
  location: 'westeurope'
  sku: {
    name:  'Standard_LRS'
  }
  kind: 'Storage'
}

resource plan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: 'plan-bicepsession-teacher'
  location: 'westeurope'
  sku: {
    name: 'F1'
    tier: 'Free'
  }
  properties: {}
}

resource func 'Microsoft.Web/sites@2022-03-01' = {
  name: 'func-bicepsession-teacher'
  kind: 'functionapp'
  location: 'westeurope'
  properties: {
    serverFarmId: plan.id
    httpsOnly: true
  }
}

resource sqlServer 'Microsoft.Sql/servers@2022-02-01-preview' = {
  name: 'sql-bicepsession-teacher'
  location: 'westeurope'
  properties:{
    administratorLogin: 'bicepuser'
    administratorLoginPassword: 'Qwerty123!'
  }
}

resource sqlDb 'Microsoft.Sql/servers/databases@2022-02-01-preview' = {
  name: 'sqldb-bicepsession-teacher'
  location: 'westeurope'
  parent: sqlServer
}

resource appi 'Microsoft.Insights/components@2015-05-01' = { 
  name: 'appi-bicepsession-teacher'
  location: 'westeurope'
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

