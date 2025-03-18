# Moc_DynamicsCustomerService
Mockup Aplikacji bazującej się na podstawowych funkcjonalnościach MS Dynamics Customer Service. 

Aplikacja bazująca się na podstawowych funkcjonalnościach MS Dynamics Customer Service. System jest przeznaczony do nauki m.in. zdrowego projektowania bazy danych i domyślone story, technologie używane w projekcie to: .NET, Entity Core framework, Nuxt. Diagram zawiera następujące główne encje i relacje: 

# Główne encje
KONTAKT - dane osób kontaktowych klientów
KONTO - dane firm/organizacji klientów
SPRAWA - zgłoszenia serwisowe, zapytania, problemy
UZYTKOWNIK - pracownicy korzystający z systemu
NOTATKA - notatki dodawane do spraw
UMOWA_SLA - umowy serwisowe określające poziom usług
PRODUKT - produkty lub usługi oferowane klientom
LICENCJA - licencje na produkty posiadane przez klientów
EMAIL - korespondencja związana ze sprawami
RAPORT - zapisane raporty i analizy
# Kluczowe relacje
Konto może posiadać wielu Kontaktów (jeden-do-wielu)
Sprawa może być zgłoszona przez Kontakt (jeden-do-wielu)
Sprawa może dotyczyć Konta (jeden-do-wielu)
Użytkownik obsługuje wiele Spraw (jeden-do-wielu)
Do Sprawy można dodawać wiele Notatek (jeden-do-wielu)
Konto może mieć wiele Umów SLA (jeden-do-wielu)
Konto może posiadać wiele Licencji na różne Produkty

Ten model można rozszerzyć o dodatkowe encje w zależności od szczegółowych wymagań, np.:
Baza wiedzy/artykuły pomocy
Ankiety satysfakcji klienta
Szablony odpowiedzi
Zespoły obsługi
Metryki i KPI

Diagram ERD:
[ERD_Diagram.pdf](https://github.com/user-attachments/files/19319554/ERD_Diagram.pdf)

