# code-challenge-5
Sogeti Code Challenge de Abril 2016
=====================================
Desafío #5: Reserva de trenes
-----------------------------------
Fecha límite: **3 de mayo 2016**

No siempre tenemos el lujo de trabajar desde cero. Algunas veces tenemos que utilizar sistemas externos ya creados para poder hacer nuestra lógica de negocio. Por ejemplo, las compañías ferroviarias (ejem...) no son un ejemplo de modernidad y tienen, en general, muchos sistemas antiguos con los que hay que interactuar. De esto va nuestro challenge de este mes.

Somos los responsables de implementar un sistema de reservas de billetes de tren, y nos piden completar el sistema del que ya existen algunas piezas. Esta vez los tests unitarios serán más bien de integración, porque no sólo llamarán a nuestra clase de reserva sino también a sistemas externos que tendremos que controlar.

El ejemplo del challenge está sacado del GitHub de Emily Bache: https://github.com/emilybache/KataTrainReservation.

Reglas de negocio de las reservas ferroviarias
----------------------------------------------
Como norma general, no se puede reservar más del 70% del pasaje del tren, así que se deja un 30% de la capacidad para la venta en taquilla. Idealmente, todos los vagones del tren deberían estar llenos al un 70% máximo, pero no siempre es el caso. Hay otra regla de negocio que dice que todos los asientos de una misma reserva _deben_ ir juntos en el mismo vagón. Si para hacer esto hay que ocupar ese vagón a más del 70%, se permite, siempre y cuando la ocupación general del tren no sea de más de 70%.  

El sistema de reserva
---------------------
El sistema de reserva tiene que ser un servicio HTTP (o, si lo veis demasiado difícil, un programa de consola que escriba el JSON por pantalla) que escuche una petición POST y que reciba datos del nombre del tren y cuantos billetes se quieren reservar. Como resultado, debe devolver una respuesta JSON detallando la reserva con tres campos: 

* **booking_id**: id de la reserva
* **train_id**: nombre del tren
* **seats**: asientos reservados (un array de ids de asientos reservados)

Ejemplo:
```
  {"train_id": "express_2000", "booking_reference": "75bcd15", "seats": ["1A", "1B"]}
```
Si no se pueden reservar los billetes que pide el usuario, se devolverá un resultado igual pero con los campos booking_reference y seats vacíos.

¿De qué partimos?
-----------------
Esta vez tenemos piezas de funcionalidad ya existentes. El servicio de referencias de reservas y el de información de trenes están ya implementados como servicios HTTP y disponibles como paquete WebDeploy implementado en ASP.NET en el repositorio de GitHub. Tenéis que crear un sitio de IIS local y desplegar el paquete allí. (XYZ en las URL indica el puerto de nuestro sitio web).

### Referencias de reservas
Para generar números de reservas, arrancamos el servidor web y hacemos un GET a la URL:
```
http://localhost:XYZ/booking_reference
```
Nos devolverá un string con un identificador nuevo de reserva:
```
75bcd15
```
### Información de trenes
El mismo servicio web aloja el servicio de información de trenes. Este servicio es el responsable de dar información de ocupación de un tren, de reservar asientos en el tren y de resetear la información del tren. Siempre se nos pedirá el identificador del tren que queremos reservar.

Para pedir información sobre el tren _express_2000_, haremos un GET a la URL:
```
http://localhost:XYZ/data_for_train/express_2000
```
Nos devolverá un JSON con la ocupación del tren:
```
{"seats": {"1A": {"booking_reference": "", "seat_number": "1", "coach": "A"}, "2A": {"booking_reference": "", "seat_number": "2", "coach": "A"}}}
```
Fijaos que los asientos se llaman 1A, 2A.. donde 1 es el número del asiento y A es el vagón (coach). Si un asiento no tiene ninguna "booking_reference", significa que está disponible para ser reservado.

Para hacer la reserva de los asientos, haremos una llamada POST a la URL:
```
http://localhost:XYZ/reserve
```
Le pasaremos los parámetros de la reserva, en formato JSON
```
{"train_id": "express_2000", "booking_reference": "75bcd15", "seats": ["1A", "1B"]}
```
Nos devolverá un JSON con la ocupación del tren después de hacer la reserva, o un error si no existen los asientos o ya están ocupados con otra reserva.

Al final, si queremos borrar todas las reservas de un tren, haremos una llamada POST a la URL con el nombre del tren:
```
http://localhost:XYz/reset/express_2000
```

Restricciones
-------------
*  **Se tienen que implementar los tests de integración y de funcionalidad con MSTest** (el estándar incluído con Visual Studio). Podéis usar el código starter de https://github.com/emilybache/KataTrainReservation/tree/master/csharp
* Vigilar de que el programa resultante esté debidamente encapsulado en clases y métodos públicos y privados
* El código debe ser compatible con Visual Studio 2013 y NET Framework 4.5.2

Suposiciones
------------
* Hay sólo 2 trenes en el sistema, llamados "express_2000" y "local_1000". 


¿Cómo subir mi código a GitHub?
===============================
En vez de enviar el código a mi correo, tenéis que hacer lo siguiente:
* Hacer un fork de este repositorio (el de SogetiSpain, no el mío personal)
* Crear una carpeta con vuestro nombre
* Crear vuestra solución en esa carpeta
* Hacer _commit_ en vuestro fork
* Hacer un _pull request_ para que lo incluyamos en el repositorio al final del tiempo del desafío

Tenéis una guía de como hacer un fork y pull request en GitHub [aquí](https://help.github.com/articles/fork-a-repo/)




