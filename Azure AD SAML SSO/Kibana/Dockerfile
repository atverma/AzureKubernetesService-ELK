# KIBANA
FROM docker.elastic.co/kibana/kibana:6.4.1
COPY instance.crt /usr/share/kibana/config/
COPY instance.key /usr/share/kibana/config/
COPY elastic-stack-ca.pem /usr/share/kibana/config/