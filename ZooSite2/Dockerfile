FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out -r linux-x64

# build runtime image
FROM microsoft/dotnet:2.0-runtime 
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "run"]