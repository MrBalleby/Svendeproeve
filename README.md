# Intro 
Verdo for målene.
Den 05-03-2020 indførte Verdo en fælles rejse mod at arbejde målrettet med FNs Verdensmål,
for at understøtte den grønne omstilling frem mod 2030.
Kompetencen og ikke mindst viljen, for at nå nye højder inden for disse mål,
bobler rundt omkring i afdelingerne, og ikke mindst i kantinen.
Kantinen har desværre oplevet et større forbrug af madspild,
hvilket resulterede i at der, i uge 37 – 2022,
blev taget initiativet til at sætte større fokus på madspild.
Dette vil derved være med til at understøtte det 12. Verdensmål – 12.3.
” Inden 2030 skal det globale madspild på detail- og forbrugerniveau pr. indbygger halveres og fødevaretab i produktions- og forsyningskæder,
herunder tab af afgrøder efter høst, skal reduceres.” 
og, understøtte Verdo’s fælles arbejde med Verdensmålene.


# Projektet
Projektet består af et komplet kantinesystem, med mulighed for tilføjelse af moduler.
I dette respository er CanteenSystems & CanteenSystemsApi de to projekter der bruges.

    1. CanteenSystems
        Dette er den administrative indgang til kantinesystemet,
        hvor der kan oprettes/slettes og ændres varer og varekategorier.
        Der er også indbygget mulighed for at se data over spisende i kantinen.
        Herunder, er det muligt at eksportere data til CSV eller JSON fil.
    2. CanteenSystemsApi 
        Dette er "hjernen" bag systemet, der gør der muligt at sende data frem & tilbage,
        samt indlæse & læse fra databasen der ligger bagved systemet.

        Da at systemet er tiltænkt at skulle ligge på en Cloud-løsning, er der ikke indbygget intergreret sikkerhed, da dette ville ske i fx. Azure.

# Test af systemet
    1. For at testste systemet skal det først hentes ned lokalt.
    2. Herefter skal databasen bagved systemet oprettes.
    3. Der kan nu vælges hvilket projekt der skal testes.
    4. For at teste CanteenSystemsApi, kan der med fordel vælges HTTP, da dette vil åbne det indbyggede Swagger til at teste igennem.