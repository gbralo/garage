terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "2.92.0"
    }
  }
}

provider "azurerm" {
      features {}
}

resource "azurerm_resource_group" "tf_test" {
    name = "garage"
    location = "West Europe"
}

resource "azurerm_container_group" "tfcg_test" {
    name                    = "garageapi"
    location                = azurerm_resource_group.tf_test.location
    resource_group_name     = azurerm_resource_group.tf_test.name

    ip_address_type         = "public"
    dns_name_label          = "garagepi"
    os_type                 = "Linux"

    container {
        name        = "garageapi"
        image       = "gbralo/garageapi"
        cpu         = "1"
        memory      = "1"

        ports {
            port        = 80
            protocol    = "TCP"
        }
    }



}

