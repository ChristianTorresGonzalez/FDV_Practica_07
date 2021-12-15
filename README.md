# Practica_07_ChristianTorresGonzalez

Para la realización de esta séptima práctica, partiré de la escena desarrollada para la práctica anterior, de tal forma que partiendo de las implementaciones y scripts anteriores, continuaré con los puntos que se solicitan. Esos puntos que se solicitan son los siguientes:
-   Cámara con seguimiento al personaje A. Se debe configurar el seguimiento hacia adelante. Esta cámara es la que debe tener la máxima prioridad.
-   Cámara con seguimiento al personaje B. Debe configurarse una zona de seguimiento del personaje B más amplia que la de A.
-   Cámara que hace el seguimiento de ambos personajes.
-   Crear una zona de confinamiento de A que abarque toda la escena.
-   Se debe crear una zona de confinamiento de la cámara B que abarque una parte de la escena.
-   Añadir un objeto que genere una vibración en la cámara cuando A choca con el
-   Seleccionar un conjunto de teclas que permitan hacer el cambio de la cámara de los personajes a la cámara que sigue al grupo. (Habilitar/Deshabilitar el gameobject de la cámara virtual)

Como consideración, hay que tener en cuenta, que la idea de esta practica es trabajar con el plugin **Cinemachine**  el cual tendré que instalar de **Unity Registry**. Para ponernos un poco en contexto, este plugin permite añadir cámaras virtuales, entre las cuales se podrá ir cambiando, además de otras funcionalidades como añadir una zona de confinamiento, es decir, una zona que funcionara como limite de movimiento de nuestra cámara.
 

## Seguimiento de personajes
La primera tarea de esta practica, es la de añadir dos cámaras para seguir a dos personajes, respectivamente. La cámara del personaje A, será la cámara que ya tenemos incluida en nuestra escena, es decir la cámara principal. Para el personaje B, añadiré una cámara virtual, la cual se cambiara como cámara principal en el momento que mueva este personaje, además, la zona que abarca esta segunda cámara será mayor que la cámara del personaje A. Para poder realizar esta primera tarea, para realizar el cambio de camara, lo que he hecho ha sido añadir una nueva camara a mi escena, la cual le he asignado que siga el personaje B, y para poder ponerla como principal, lo que he hecho ha sido añadirle una prioridad mayor:

- Cámara del personaje A
  ![Alt text](/img/camaraA.img)
  ![Alt text](/img/camaraA.gif)
  
- Cámara del personaje B
  ![Alt text](/img/camaraB.img)
  ![Alt text](/img/camaraB.gif)
