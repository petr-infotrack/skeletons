#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 56074
EXPOSE 44334

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["api-net-core/api-net-core.csproj", "api-net-core/"]
RUN dotnet restore "api-net-core/api-net-core.csproj"
COPY . .
WORKDIR "/src/api-net-core"
RUN dotnet build "api-net-core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api-net-core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api-net-core.dll"]