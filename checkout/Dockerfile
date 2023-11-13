# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /src
COPY src/*.csproj .
RUN dotnet restore
COPY src .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
ENV ASPNETCORE_URLS=http://+:1240
COPY --from=build-env /publish .
EXPOSE 1240
ENTRYPOINT ["dotnet", "checkout.dll"]