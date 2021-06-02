FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR .
COPY *.sln .
COPY UnitTest/*.csproj UnitTest/
COPY Application/*.csproj Application/
COPY Domain/*.csproj Domain/
COPY Infra.Data/*.csproj Infra.Data/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /Application
RUN dotnet build
WORKDIR /UnitTest
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /Application
RUN dotnet publish -c Release -o /publish

FROM base AS final
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "Application.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Application.dll
  