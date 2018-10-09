This is code samples for second part of the series on deploying Elasticsearch, Logstash and Kibana (ELK) to Azure Kubernetes Service cluster. These samples are created to enable Azure AD SAML based single sign on to secure Elasticsearch and Kibana cluster hosted in AKS. I will also cover the steps needed to encrypt communications in ELK cluster.


Using SAML SSO for Elasticsearch with AAD means that Elasticsearch does not need to be seeded with any user accounts from the directory. Instead, Elasticsearch is able to rely on the claims sent within a SAML token in response to successful authentication to determine identity and privileges.

Kibana, as the user facing component, interacts with the user’s browser and receives all the SAML messages that the Identity Provider sends to the Elastic Stack Service Provider. Elasticsearch implements most of the functionality a SAML Service Provider needs. It holds all SAML related configuration in the form of an authentication realm and it also generates all SAML messages required and passes them to Kibana to be relayed to the user’s browser. It finally consumes all SAML Responses that Kibana relays to it, verifies them, extracts the necessary authentication information and creates the internal authentication tokens based on that. The component diagram has been updated to add Azure AD integration.

You can read more at msdn

