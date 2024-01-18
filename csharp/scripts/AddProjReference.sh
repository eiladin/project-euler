#!/bin/bash

for i in {1..65}; do
    cd Euler$i
    dotnet add reference ../Utils/Utils.csproj
    cd ..
done
