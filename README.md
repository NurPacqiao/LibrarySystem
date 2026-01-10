# 📚 System Zarządzania Biblioteką (LibraryApp)

Projekt stworzony w ramach zajęć "Bazy Danych i Aplikacje Internetowe". Jest to nowoczesna aplikacja webowa typu Full-Stack służąca do kompleksowego zarządzania zasobami bibliotecznymi.

## 📋 Opis Projektu

Aplikacja umożliwia administratorom i pracownikom biblioteki zarządzanie księgozbiorem, autorami, gatunkami oraz procesem wypożyczania książek. System posiada nowoczesny, responsywny interfejs użytkownika oraz w pełni funkcjonalny system uwierzytelniania.

## 🚀 Zrealizowane Funkcjonalności

### 🔹 Główne moduły

- **Dashboard:** Centralny panel startowy z szybkim dostępem do kluczowych sekcji.
- **Książki:** Pełna obsługa (CRUD) – dodawanie, edycja, usuwanie i przeglądanie książek.
- **Wyszukiwanie:** Możliwość filtrowania książek po tytule.
- **Wypożyczenia:** System rejestracji wypożyczeń i zwrotów z datami.
- **Autorzy i Gatunki:** Zarządzanie metadanymi bibliotecznymi.

### 🔹 Bezpieczeństwo i UI

- **Uwierzytelnianie:** System logowania i rejestracji (ASP.NET Core Identity) z nowoczesnym podziałem graficznym (Split-Screen Design).
- **Nowoczesny Interfejs:** Wykorzystanie **Bootstrap 5**, ikon **Bootstrap Icons** oraz niestandardowych stylów (gradienty, karty, cienie).
- **Responsywność:** Aplikacja dostosowana do urządzeń mobilnych i desktopowych.
- **Walidacja:** Zabezpieczenie formularzy przed błędnymi danymi.

## 🛠 Technologie

- **Backend:** .NET 8.0 (ASP.NET Core MVC)
- **Baza danych:** SQLite (Entity Framework Core)
- **Frontend:** Razor Views, Bootstrap 5, CSS3
- **Narzędzia:** Visual Studio Code, Git

## 💻 Jak uruchomić projekt

1.  **Sklonuj repozytorium:**
    ```bash
    git clone [https://github.com/twoj-nick/LibraryApp.git](https://github.com/twoj-nick/LibraryApp.git)
    ```
2.  **Przejdź do folderu projektu:**
    ```bash
    cd LibraryApp
    ```
3.  **Uruchom aplikację:**
    ```bash
    dotnet watch run
    ```
4.  Otwórz przeglądarkę pod adresem: `http://localhost:5000`

&copy; 2026 LibraryApp
