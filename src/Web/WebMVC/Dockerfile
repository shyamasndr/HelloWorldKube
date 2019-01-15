FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./
WORKDIR /app/src/Web/WebMvc
RUN dotnet restore
RUN dotnet publish -c Release -o output

# build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/src/Web/WebMvc/output .
ENTRYPOINT ["dotnet", "WebMVC.dll"]