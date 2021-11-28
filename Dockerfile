FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MSDemo.csproj", "./"]
RUN dotnet restore "MSDemo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MSDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSDemo.dll"]
