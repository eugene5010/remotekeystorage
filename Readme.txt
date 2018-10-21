Запросы к приложению можно запустить через расширение Postman
примеры запросов можно получить, используя линк
https://www.getpostman.com/collections/72027074e1fd3e1d96db
либо импортировав Postman приложенный файл
KeyValueStorage.postman_collection.json
Либо просто выполнив в Postman/любой другой rest-консоли запросы
GET {{Host}}/values/somekey - получить значение для ключа somekey
POST {{Host}}/values/somekey/somevalue - добавить значение somevalue для ключа somekey
DELETE {{Host}}/values/somekey - удалить значение для ключа somekey

где {{Host}} базовый Url приложения (по умолчанию при запуске через IIS Express http://localhost:61197)
К сожалению, подключение Swagger к NancyFx сопряжено с некоторыми сложностями, 
поэтому от его использования в рамках тестового проекта я решил отказаться