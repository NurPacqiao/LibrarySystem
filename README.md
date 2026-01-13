# 📚 System Zarządzania Biblioteką (LibraryApp)

Projekt stworzony w ramach zajęć "Bazy Danych i Aplikacje Internetowe". Jest to nowoczesna aplikacja webowa typu Full-Stack służąca do kompleksowego zarządzania zasobami bibliotecznymi.

## 📋 Opis Projektu

Aplikacja umożliwia administratorom i pracownikom biblioteki zarządzanie księgozbiorem, autorami, gatunkami oraz procesem wypożyczania książek. System posiada nowoczesny, responsywny interfejs użytkownika oraz w pełni funkcjonalny system uwierzytelniania z podziałem na role.

## 🚀 Zrealizowane Funkcjonalności

### 🔹 Główne moduły

- **Dashboard:** Centralny panel startowy z szybkim dostępem do kluczowych sekcji.
- **Książki:** Pełna obsługa (CRUD) – dodawanie, edycja, usuwanie i przeglądanie książek.
- **Wyszukiwanie:** Możliwość filtrowania książek po tytule.
- **Wypożyczenia:** System rejestracji wypożyczeń i zwrotów (dostępny dla użytkowników).
- **Autorzy i Gatunki:** Zarządzanie metadanymi bibliotecznymi (tylko dla administratora).

### 🔹 Bezpieczeństwo i UI

- **Uwierzytelnianie:** System logowania i rejestracji (ASP.NET Core Identity) z nowoczesnym podziałem graficznym (Split-Screen Design).
- **Nowoczesny Interfejs:** Wykorzystanie **Bootstrap 5**, ikon **Bootstrap Icons** oraz niestandardowych stylów (gradienty, karty, cienie).
- **Responsywność:** Aplikacja dostosowana do urządzeń mobilnych i desktopowych.
- **Walidacja:** Zabezpieczenie formularzy przed błędnymi danymi.

## 🔑 Dane Dostępowe i Uprawnienia (Ważne dla Prowadzącego)

Aplikacja posiada zaimplementowany system ról i polityk bezpieczeństwa (`AdminOnly`):

1.  **Administrator (`admin@test.com`):** Pełny dostęp do edycji, usuwania i dodawania (Książki, Autorzy, Gatunki, Wypożyczenia).
2.  **Zalogowany Użytkownik:** Dostęp do modułu Wypożyczeń (Loans) - możliwość wypożyczania książek. Brak dostępu do edycji zasobów biblioteki.
3.  **Gość (Niezalogowany):** Dostęp tylko do odczytu (przeglądanie listy książek i szczegółów).

**Konto Administratora (do testowania edycji):**

- **Email:** `admin@test.com`
- **Hasło:** `Admin123!`

_(Rejestracja nowego konta tworzy użytkownika ze standardowymi uprawnieniami, który nie może edytować bazy książek)._

## ⚙️ Konfiguracja i API

- **Baza Danych:** Projekt używa **SQLite** (`library.db`). Łańcuch połączenia (Connection String) znajduje się w pliku `appsettings.json`.
- **API Endpoint:** Zgodnie z wymaganiami projekt udostępnia punkt końcowy API (CRUD) dla głównej encji (Książki), zwracający dane w formacie JSON:
  - Adres: `/api/Api` (np. `http://localhost:5000/api/Api`)

## 🛠 Technologie

- **Backend:** .NET 8.0 (ASP.NET Core MVC)
- **Baza danych:** SQLite (Entity Framework Core)
- **Frontend:** Razor Views, Bootstrap 5, CSS3
- **Narzędzia:** Visual Studio Code, Git

## 💻 Jak uruchomić projekt

1.  **Sklonuj repozytorium:**
    ```bash
    git clone https://github.com/Nurpacqiao/LibrarySystem.git
    ```
2.  **Przejdź do folderu projektu:**
    ```bash
    cd LibrarySystem
    ```
3.  **Przywróć bazę danych (Wymagane po sklonowaniu):**
    ```bash
    dotnet ef database update
    ```
4.  **Uruchom aplikację:**
    ```bash
    dotnet watch run
    ```
5.  Otwórz przeglądarkę pod adresem: `http://localhost:5000`

---

&copy; 2026 LibraryApp
