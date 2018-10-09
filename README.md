# AzureKubernetesService-ELK

This is the sample source code for setting up Elasticsearch, Logstash and Kibana cluster in Azure Kubernetes Service (AKS) and consume messages from Event Hub.

A sample client App (e.g. IOT device) will be publishing messages to Event Hub and these messages will be ingested into Elasticsearch using 'Azure Event Hub' plugin of Logstash. The dev tools used to develop these components are Visual Studio for Mac/Visual Studio 2017, AKS Dashboard as well as kubectl commands are used to create/manager Kubernetes resources in AKS.

You can read details @ https://blogs.msdn.microsoft.com/atverma/2018/09/24/azure-kubernetes-service-aks-deploying-elasticsearch-logstash-and-kibana-elk-and-consume-messages-from-azure-event-hub/
