# DopravniKrizovatky
DOPRAVNÍ KŘIŽOVATKY – INTERAKTIVNÍ VÝUKOVÁ APLIKACE

Aplikace určená pro výuku a procvičování správného pořadí průjezdu vozidel na dopravních křižovatkách. Projekt vzniká jako školní práce.

FUNKCE APLIKACE

Hlavní menu s výběrem režimu

Režim výuky:
• Náhodné načtení dopravního scénáře ze souboru (JSON)
• Zobrazení popisu situace a správného řešení

Režim procvičování (v přípravě):
• Uživatel vybere pořadí vozidel
• Aplikace vyhodnotí správnost (bude doplněno)

Podpora různých typů křižovatek:
• Neřízená
• Semafory
• Hlavní/vedlejší
• Tramvaj
• Kruhový objezd

STRUKTURA PROJEKTU

/DopravniKrizovatky
/scenarios – JSON soubory se scénáři
MainForm.cs – hlavní menu
LearningForm.cs – režim výuky
PracticeForm.cs – režim procvičování (rozpracováno)
Scenario.cs – třídy pro načítání scénářů
README.txt

FORMÁT JSON SCÉNÁŘE (PŘÍKLAD)

{
"id": "scen01",
"title": "Neřízená křižovatka",
"type": "nerizene",
"description": "Tři vozidla přijíždějí ke křižovatce bez značek.",
"vehicles": [
{ "id": "v1", "type": "auto", "approach": "sever", "direction": "rovně" },
{ "id": "v2", "type": "auto", "approach": "východ", "direction": "rovně" },
{ "id": "v3", "type": "auto", "approach": "jih", "direction": "rovně" }
],
"explanation": "Správné pořadí: v1 → v3 → v2."
}

POUŽITÉ TECHNOLOGIE

C# (.NET Framework 4.7.2)

Windows Forms

System.Text.Json (načítání JSON)

Git / GitHub

PLÁN DALŠÍHO VÝVOJE

Náhodné načítání scénářů (hotovo)

UI pro procvičování (probíhá)

Vyhodnocení správného pořadí

Grafické znázornění vozidel a křižovatek

Animace průjezdu (možné rozšíření)

ÚČEL PROJEKTU

Projekt vytvořen jako školní úkol pro procvičení:

WinForms

práce se soubory (JSON)

objektové programování (OOP)

verzování projektů v Git a GitHub
