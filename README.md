# Transkoll mobile app

VR applications are getting more and more into our lives. This app is an example prototype for displaying various product-specific information. The following application is based on Unity Engine for tracking consumer products with augmented reality features provided by Vuforia.

## Requirements

+ Unity 2018.2.17 or higher with integrated Vuforia SDK.
+ Vuforia Account with License and Key and a given product database.
+ Android SDK for android build support (optional)

## General concept

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/info.png "Example of tracking a product and displaying additional information")

## Example Target Images

A pdf, showing three different examples can be found [here.](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/koelln_product_images.pdf "Navigate to example tracking images")


## Freezing current camera state

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/freeze.jpg "Freeze Feature for information")

On the lower left the user can freeze the current camera state. Thus the user can read the displayed text withour holding the phone straight on the product. 

## Database synchronization

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/database-sync.jpg "Sync Feature for information")

By clicking the SYNC button the information will be downloaded in a local SQLite database on the device.

## Export program
Program can be exported on different devices for different operating systems. Currently Android and Windows are support out of the box.

## Links

[Transkoll Preview](http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=product "Products")

[Transkoll Preview](http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=una "UNA")


## JSON Format Examples


JSON String for products

```javascript
{  
   "status":"ok",
   "products":[  
      {  
         "Produkt_ID":"1-Produkt_1",
         "Name":"Produkt 1",
         "Detailbeschreibung":null,
         "Produktnummer":"1",
         "Unternehmen":"wigital GmbH"
      },
      {  
         "Produkt_ID":"1-K\u00f6lln_M\u00fcsli_Knusper_Honig-Nuss",
         "Name":"K\u00f6lln M\u00fcsli Knusper Honig-Nuss",
         "Detailbeschreibung":"leckeres honig nuss m\u00fcsli",
         "Produktnummer":"1",
         "Unternehmen":"Uni Kiel"
      },
      {  
         "Produkt_ID":"1-K\u00f6lln_M\u00fcsli_Schoko",
         "Name":"K\u00f6lln M\u00fcsli Schoko",
         "Detailbeschreibung":null,
         "Produktnummer":"1",
         "Unternehmen":"Uni Kiel"
      }
   ]
}
```

JSON String for UNA (Unternehmen Nachhaltigkeitsaktivitäten)

```javascript
{  
   "status":"ok",
   "products":[  
      {  
         "Produkt_ID":"1-K\u00f6lln_M\u00fcsli_Knusper_Honig-Nuss",
         "Produkt_Name":"K\u00f6lln M\u00fcsli Knusper Honig-Nuss",
         "Nachhaltigskeitsdimensionen":{  
            "Regional":[  
               {  
                  "UNA_Name":"K\u00f6lln engagiert sich f\u00fcr den regionalen Anbau von Hafer der die wichtigste Zutat von K\u00f6lln-Produkten ist.",
                  "Massnahme":[  
                     "K\u00f6lln tauscht sich regelm\u00e4\u00dfig mit den H\u00e4ndlern aus dem Norden zu den Qualit\u00e4tskriterien des Hafers aus.",
                     "F\u00fcr das Produkt Zarte K\u00f6llnflocken Glutenfrei wird ein Gro\u00dfteil des Hafers in Norddeutschland erzeugt."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln bezieht den Hafer f\u00fcr sein M\u00fcsli regional aus Norddeutschland und aus dem skandinavischen Raum.",
                  "Massnahme":[  
                     "K\u00f6lln produziert in Norddeutschland und kann somit die r\u00e4umliche N\u00e4he zu seinen Lieferanten gew\u00e4hrleisten.",
                     "Das milde Klima in der n\u00f6rdlichen Region bietet sehr gute Vorraussetzungen f\u00fcr Haferanbau."
                  ]
               }
            ],
            "Saisonal":[  
               {  
                  "UNA_Name":"K\u00f6lln engagiert sich f\u00fcr den regionalen Anbau von Hafer der die wichtigste Zutat von K\u00f6lln-Produkten ist.",
                  "Massnahme":[  
                     "K\u00f6lln tauscht sich regelm\u00e4\u00dfig mit den H\u00e4ndlern aus dem Norden zu den Qualit\u00e4tskriterien des Hafers aus.",
                     "F\u00fcr das Produkt Zarte K\u00f6llnflocken Glutenfrei wird ein Gro\u00dfteil des Hafers in Norddeutschland erzeugt."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln bezieht den Hafer f\u00fcr sein M\u00fcsli regional aus Norddeutschland und aus dem skandinavischen Raum.",
                  "Massnahme":[  
                     "K\u00f6lln produziert in Norddeutschland und kann somit die r\u00e4umliche N\u00e4he zu seinen Lieferanten gew\u00e4hrleisten.",
                     "Das milde Klima in der n\u00f6rdlichen Region bietet sehr gute Vorraussetzungen f\u00fcr Haferanbau."
                  ]
               }
            ],
            "\u00d6kologisch":[  
               {  
                  "UNA_Name":"K\u00f6lln arbeitet kontinuierlich daran, die durch die Produktion erzeugten Umweltbelastungen zu reduzieren.",
                  "Massnahme":[  
                     "K\u00f6lln bezieht am Standort Elmshorn Strom aus erneuerbaren\/regenerativen Energien.",
                     "K\u00f6lln reduziert die Anzahl der ben\u00f6tigten LKWs und damit den CO2-Aussta\u00df beim Transport."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln w\u00e4hlt die Verpackung so aus, dass \u00f6kologische Aspekte und Produktschutz zusammengef\u00fchrt werden..",
                  "Massnahme":[  
                     "Durch eine spezielle Barriereschicht sch\u00fctzt der Innenbeutel das M\u00fcsli vor Umwelteinfl\u00fcssen.",
                     "Die \u00e4u\u00dfere Faltschachtel der Verpackung ist zu 100% recyclebar."
                  ]
               }
            ]
         }
      },
      {  
         "Produkt_ID":"1-K\u00f6lln_M\u00fcsli_Schoko",
         "Produkt_Name":"K\u00f6lln M\u00fcsli Schoko",
         "Nachhaltigskeitsdimensionen":{  
            "Regional":[  
               {  
                  "UNA_Name":"K\u00f6lln engagiert sich f\u00fcr den regionalen Anbau von Hafer der die wichtigste Zutat von K\u00f6lln-Produkten ist.",
                  "Massnahme":[  
                     "K\u00f6lln tauscht sich regelm\u00e4\u00dfig mit den H\u00e4ndlern aus dem Norden zu den Qualit\u00e4tskriterien des Hafers aus.",
                     "F\u00fcr das Produkt Zarte K\u00f6llnflocken Glutenfrei wird ein Gro\u00dfteil des Hafers in Norddeutschland erzeugt."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln bezieht den Hafer f\u00fcr sein M\u00fcsli regional aus Norddeutschland und aus dem skandinavischen Raum.",
                  "Massnahme":[  
                     "K\u00f6lln produziert in Norddeutschland und kann somit die r\u00e4umliche N\u00e4he zu seinen Lieferanten gew\u00e4hrleisten.",
                     "Das milde Klima in der n\u00f6rdlichen Region bietet sehr gute Vorraussetzungen f\u00fcr Haferanbau."
                  ]
               }
            ],
            "Saisonal":[  
               {  
                  "UNA_Name":"K\u00f6lln engagiert sich f\u00fcr den regionalen Anbau von Hafer der die wichtigste Zutat von K\u00f6lln-Produkten ist.",
                  "Massnahme":[  
                     "K\u00f6lln tauscht sich regelm\u00e4\u00dfig mit den H\u00e4ndlern aus dem Norden zu den Qualit\u00e4tskriterien des Hafers aus.",
                     "F\u00fcr das Produkt Zarte K\u00f6llnflocken Glutenfrei wird ein Gro\u00dfteil des Hafers in Norddeutschland erzeugt."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln bezieht den Hafer f\u00fcr sein M\u00fcsli regional aus Norddeutschland und aus dem skandinavischen Raum.",
                  "Massnahme":[  
                     "K\u00f6lln produziert in Norddeutschland und kann somit die r\u00e4umliche N\u00e4he zu seinen Lieferanten gew\u00e4hrleisten.",
                     "Das milde Klima in der n\u00f6rdlichen Region bietet sehr gute Vorraussetzungen f\u00fcr Haferanbau."
                  ]
               }
            ],
            "\u00d6kologisch":[  
               {  
                  "UNA_Name":"K\u00f6lln w\u00e4hlt die Verpackung so aus, dass \u00f6kologische Aspekte und Produktschutz zusammengef\u00fchrt werden..",
                  "Massnahme":[  
                     "Durch eine spezielle Barriereschicht sch\u00fctzt der Innenbeutel das M\u00fcsli vor Umwelteinfl\u00fcssen.",
                     "Die \u00e4u\u00dfere Faltschachtel der Verpackung ist zu 100% recyclebar."
                  ]
               },
               {  
                  "UNA_Name":"K\u00f6lln arbeitet kontinuierlich daran, die durch die Produktion erzeugten Umweltbelastungen zu reduzieren.",
                  "Massnahme":[  
                     "K\u00f6lln bezieht am Standort Elmshorn Strom aus erneuerbaren\/regenerativen Energien.",
                     "K\u00f6lln reduziert die Anzahl der ben\u00f6tigten LKWs und damit den CO2-Aussta\u00df beim Transport."
                  ]
               }
            ]
         }
      }
   ]
}
```
