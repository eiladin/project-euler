cd ${0%/*} || exit

problem=$1

if [ -z "$problem" ]; then
    echo "Problem number is required"
    exit 1
fi

cd ..

dotnet new console -n Euler$problem
