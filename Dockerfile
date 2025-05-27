# Giai đoạn build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy toàn bộ code vào image
COPY . ./
RUN dotnet publish -c Release -o out

# Giai đoạn runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# ⚠️ Sửa tên dưới đây thành đúng tên file .csproj của bạn
ENTRYPOINT ["dotnet", "backend.dll"]
