FROM node:14.15.5-slim as build
WORKDIR /appp
COPY src ./src
COPY *.json ./
RUN npm install -g @angular/cli@11.2.1
RUN npm install
RUN ng build --prod

FROM nginx:alpine as deploy
WORKDIR /appp

COPY --from=build /app/nginx.conf /etc/nginx/conf.d/default.conf