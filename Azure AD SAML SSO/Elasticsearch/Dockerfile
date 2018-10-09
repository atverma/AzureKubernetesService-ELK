# Elasticsearch
FROM docker.elastic.co/elasticsearch/elasticsearch:6.4.1
COPY --chown=elasticsearch:elasticsearch elastic-stack-ca.p12 /usr/share/elasticsearch/config/
COPY --chown=elasticsearch:elasticsearch elastic-certificates.p12 /usr/share/elasticsearch/config/
COPY --chown=elasticsearch:elasticsearch Elasticsearch.xml /usr/share/elasticsearch/config/

RUN /bin/bash -c "echo Password1$ | /usr/share/elasticsearch/bin/elasticsearch-keystore add xpack.security.transport.ssl.keystore.secure_password  -xf"
RUN /bin/bash -c "echo Password1$ | /usr/share/elasticsearch/bin/elasticsearch-keystore add xpack.security.transport.ssl.truststore.secure_password  -xf"
RUN /bin/bash -c "echo Password1$ | /usr/share/elasticsearch/bin/elasticsearch-keystore add xpack.security.http.ssl.keystore.secure_password  -xf"
RUN /bin/bash -c "echo Password1$ | /usr/share/elasticsearch/bin/elasticsearch-keystore add xpack.security.http.ssl.truststore.secure_password  -xf;"