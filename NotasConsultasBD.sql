/*==============================================================================================
para concatenar valores res: 0000123
================================================================================================*/

select LPAD('123',7,'0000000') Lote

/*==============================================================================================
para rellenar espacios en vacio
================================================================================================*/

NVL(emp_name, 'AAA')


/*==============================================================================================
Merge te permite tomar dos tablas, compararlas en función al criterio determinado y 
realizar las acciones definidas en caso de cumplir la condición,y en caso que no también
================================================================================================*/

MERGE INTO TABLA1 
   USING (TABLA2) 
   ON (CONDICION DE UNION)
   WHEN MATCHED THEN UPDATE SET columna = expresion WHERE (CONDICION WHEN-MATCHED)
     DELETE WHERE (CONDICION DELETE)
   WHEN NOT MATCHED THEN INSERT (columas)
     VALUES (valores)
     WHERE (CONDICION NOT-MATCHED)


/*==============================================================================================
BETWEEN
Si anteponemos la condición Not devolverá aquellos valores no incluidos en el intervalo.

(Devuelve el valor 'Provincial' si el código postal se encuentra en el intervalo, 'Nacional' en caso contrario)
================================================================================================*/     

SELECT IIf(CodPostal Between 28000 And 28999, 'Provincial', 'Nacional') FROM Editores;


/*==============================================================================================
LIKE
-Si anteponemos la condición Not devolverá aquellos valores no incluidos en el intervalo.
================================================================================================*/  

Like 'C*'  --devuelve todos los valores de campo que comiencen por la letra C
Like 'P[A-F]###' --datos que comienzan con la letra P seguido de cualquier letra entre A y F y de tres dígitos
Like '[A-D]*'  --datos que empiece con una letra de la A a la D seguidas de cualquier cadena
Like 'a*a'  -- datos que comienzan con a y termine con a
like 'ab*' -- datos  que comiencen con ab y contine Varios caracteres
like 'a?a'  --datos que tengan cualquier variable entre los a ('aaa', 'a3a', 'aBa')
like 'a#a'  -- datos que tengan un digito numérico entre las a ('a0a', 'a1a', 'a2a')
like '[a-z]'  -- datos que solo tengan caracteres entre esos rangos ('f', 'p', 'j')
like '[!a-z]' -- datos que estén Fuera de ese rango  ('9', '&', '%')
like '[!0-9]' -- datos Distinto de un dígito ('A', 'a', '&', '~')
like 'a[!b-m]#'  -- datos combinados ('An9', 'az0', 'a99')


/*==============================================================================================
IN 
Este operador devuelve aquellos registros cuyo campo indicado coincide con alguno de los en una lista.
================================================================================================*/  

 SELECT * FROM Pedidos WHERE Provincia In ('Madrid', 'Barcelona', 'Sevilla');