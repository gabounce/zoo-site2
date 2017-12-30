FROM microsoft/aspnetcore-build:2.0 as build-env

WORKDIR /app
RUN dotnet restore

RUN dotnet build -c release
RUN dotnet publish -c release -o app

COPY /app /app

RUN docker build -t zooSite2 .

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "ZooSite2.dll"]