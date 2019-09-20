#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["Interview.Test.Intermediate2/Interview.Test.Intermediate2.csproj", "Interview.Test.Intermediate2/"]
RUN dotnet restore "Interview.Test.Intermediate2/Interview.Test.Intermediate2.csproj"
COPY . .
WORKDIR "/src/Interview.Test.Intermediate2"
RUN dotnet build "Interview.Test.Intermediate2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Interview.Test.Intermediate2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Interview.Test.Intermediate2.dll"]