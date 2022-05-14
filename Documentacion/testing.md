Cosas que hay que testear:

- En general el tamaño de todos los objetos y como se ven en VR.

- Minijuego de recursos:
    - Tiempo del minijuego de talar madera y picar piedra (Clase ResourceStation variable time)
    - velocidad a la que gira la roca en grados / segundo (Clase ResourceStation variable speed)
    - Cooldown para golpear la piedra (Clase Pickaxe variable cooldownrock).
    - Fuerza que necesitas para que la colisión sea valida (Clase Axe y Pickaxe variable neededSpeed)

- Minijuego del laser:
    - Distancia máxima del laser a la linea (Clase Mold variable LINE_THRESHOLD)
    - Distancia a la que tiene que estar el laser del punto para pasar al siguiente (POINT_THRESHOLD)
    (Realmente puedes poner el mismo valor en las 2)
    
- Minijuego de la forja:
    - Distancia mínima entre el punto de colisión del martillo y el marcador (Clase AnvilCollider variable Threshold).
    - Fuerza necesaria para cada nivel (Clase AnvilStations variable Strenght_Levels).    
