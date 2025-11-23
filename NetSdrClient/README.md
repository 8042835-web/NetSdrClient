# NetSdrClient Labs (1–8)

Це навчальний репозиторій, який можна використати як готову основу
для 8 лабораторних з реінжинірингу ПЗ.

У ньому вже є:

- консольний застосунок `NetSdrClientApp` (.NET 8)
- юніт‑тести з покриттям (coverlet) для Лаб 3 та 6
- приклади "code smells" і прості дублікати коду для Лаб 2 та 4
- проєкт архітектурних тестів `NetSdrClient.ArchTests` на базі NetArchTest (Лаб 5)
- налаштований CI workflow `sonarcloud.yml` для GitHub Actions (Лаб 1, 3, 4, 6, 8)
- налаштований Dependabot (`.github/dependabot.yml`) для Лаб 7

Для повного проходження курсу тобі потрібно:

1. Створити публічний репозиторій на GitHub і завантажити сюди цей код.
2. Підключити SonarCloud, створити `SONAR_TOKEN` і додати його у Secrets.
3. У файлі `.github/workflows/sonarcloud.yml` замінити `YOUR_PROJECT_KEY` і `YOUR_ORG_KEY`
   на реальні значення з SonarCloud.
4. Поступово виконувати кроки з методички, створюючи Pull Request для кожної лаби.
Test trigger for GitHub Actions
