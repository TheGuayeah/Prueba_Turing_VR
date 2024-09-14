# Prueba Turing VR
 
Para probar el proyecto sin necesidad de dispositivo he utilizado el prefab `XR Device Simulator`, pero debería funcionar igualmente conectando unas Meta Quest.

## Controles del simulador

- (mientras se controla la cámara) `W`/`A`/`S`/`D` para mover al jugador.
- `Mover el mouse` para controlar la cámara.
- `TAB` para cambiar entre mando Dcho e Izdo o mover la cámara.
- Mientras se controla un mando.
  - `W` + `Apuntar con el mando` para teletransportarse.
  - `A`/`D` para girar 90º.
  - `S` para girar 180º.
  - `G` para agarrar un objeto.
  - `R` para alternar entre girar o mover el mando.
  - `B` para abrir el inventario.
  - `Click Izdo` para interactuar con los objetos.

## Interacciones

- En la mesa están los objetos con los que se puede interactuar.
- Al apuntar un objeto con uno de los mandos y manterner pulsada la tecla `G`, el objeto se traslada hasta la posición del mando.
- Al soltar la tecla `G` el objeto que hay en la mano se cae al suelo.
- El arma se utiliza mientras está en la mano, pulsando `Click Izdo`.
- La poción se utiliza mientras está en la mano, pulsando `Click Izdo`.
- La munición se recarga mientras el cargador está en la mano, pulsando `Click Izdo`

## Inventario

- Al inicio el inventario está vacío y se puede rellenar con los objetos azules (interacuables).
- Cada slot del inventario detecta cuando tiene un bojeto tipo <Item> con un colider cerca y se coloca automáticamente al soltar el objeto dejando de pulsar la tecla `G`.
- No se puede colocar un objeto en un slot ocupado.