FROM mkenney/npm:node-10-alpine AS frontend
WORKDIR /app

COPY ./ ./
WORKDIR frontend

RUN npm install
RUN npm run-script build
