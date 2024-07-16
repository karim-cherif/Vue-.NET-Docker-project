# Build stage
FROM node:lts as build-stage
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Production stage
FROM nginx:stable as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]



#alternate docker file using http-server

# Use an official Node runtime as the base image
#FROM node:20.15

# Set the working directory in the container
#WORKDIR /app

# Copy package.json and package-lock.json to the working directory
#COPY package*.json ./

# Install the application dependencies
#RUN npm install

# Copy the rest of the application code
#COPY . .

# Build the application
#RUN npm run build

# Install a simple HTTP server for serving static content
#RUN npm install -g http-server

# Expose the port the app runs on
#EXPOSE 8080

# Define the command to run the app
#CMD [ "http-server", "dist" ]