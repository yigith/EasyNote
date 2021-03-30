### Projeyi GitHub'dan Klonladıktan Sonra

1. Solution klasörü içerisinde AppSettingsSecrets.config adında bir dosya oluşturun ve içeriği şu şekilde olsun:

```xml
<appSettings>
	<add key="SmtpUserName" value="user@example.com" />
	<add key="SmtpPassword" value="***********" />
	<add key="GoogleClientId" value="**********" />
	<add key="GoogleClientSecret" value="**********" />
</appSettings>
```

2. Proje klasörü içerisinde ConnectionStrings.config adında bir dosya oluşturun ve içeriği şu şekilde olsun:

```xml
<connectionStrings>
	<add name="DefaultConnection" connectionString="server=***;database=***;user id=***;password=***" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Not: Bu connection string publish aşamasında web.config içerisindeki connection strings ile otomatik olarak değiştirilir.