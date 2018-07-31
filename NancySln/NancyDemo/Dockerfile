FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY NancyDemo/*.csproj ./NancyDemo/
RUN dotnet restore

# copy everything else and build app
COPY NancyDemo/. ./NancyDemo/
WORKDIR /app/NancyDemo
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/NancyDemo/out ./
ENTRYPOINT ["dotnetcore", "nancy", "NancyDemo.dll"]