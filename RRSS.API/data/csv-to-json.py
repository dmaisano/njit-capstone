from csv import DictReader
from json import dump, dumps
from os import path

scriptPath = path.abspath(path.dirname(__file__))

csvFile = open(path.join(scriptPath, "airports.csv"), "r", encoding="utf-8")
csvLines = csvFile.readlines()[1:]
jsonFile = open(path.join(scriptPath, "airports.json"), "w", encoding="utf-8")

reader = DictReader(
    csvLines,
    fieldnames=(
        "ident",
        "type",
        "name",
        "latitude_deg",
        "longitude_deg",
        "iso_country",
        "iso_region",
    ),
)

data = []
for row in reader:
    data.append(row)

jsonFile.write(dumps(data, ensure_ascii=False))
# jsonFile.write(dumps(data, indent=2, separators=(",", ": "), ensure_ascii=False))