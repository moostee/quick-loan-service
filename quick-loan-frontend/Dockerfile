FROM johnpapa/angular-cli as angular-built
WORKDIR /usr/src/app
COPY package.json package.json
RUN npm install --silent
COPY . .
RUN ng build --prod

FROM nginx:alpine
LABEL author="mustapha akinsola"
COPY --from=angular-built /usr/src/app/dist /usr/share/nginx/html
EXPOSE 80 443
CMD [ "nginx", "-g", "daemon off;" ]