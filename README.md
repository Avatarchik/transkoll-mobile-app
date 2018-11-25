# Transkoll mobile app

VR applications are getting more and more into our lives. This app is an example prototype for displaying various product-specific information. The following application is based on Unity Engine for tracking consumer products with augmented reality features provided by Vuforia.

## Requirements

+ Unity 2018.2.17 or higher with integraded Vuforia SDK.
+ Vuforia Account with License and Key and a given product database.
+ Android SDK for android build support (optional)

## General concept

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/info.png "Example of tracking a product and displaying additional information")

## Transkoll Web API

The programm can get its information via REST API inf the following code format:

## Freezing current camera state

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/freeze.jpg "Freeze Feature for information")

On the lower left the user can freeze the current camera state. Thus the user can read the displayed text relaxed. 

## Database synchronization

![alt text](https://github.com/julian-martin/transkoll-mobile-app/blob/master/doc/database-sync.jpg "Sync Feature for information")

By clicking the SYNC button the information will be downloaded in a local SQLite database on the device.

## Export program
Program can be exported on different devices for different operating systems. Currently Android and Windows are support out of the box.

## Links

[Transkoll Preview](http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=product "Products")

[Transkoll Preview](http://preview.transkolldb.wigital.de/webservice/?key=7PS0r8IHhFNELSlj1xQiT1XXKHhfiV0G&function=una "UNA")

