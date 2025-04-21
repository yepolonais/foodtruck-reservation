set -e

echo "Installation des nugets"

dotnet restore
echo "Démarrage de l'API truckspot"
dotnet watch run --urls=http://0.0.0.0:5051