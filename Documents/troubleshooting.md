

 |Tabela de dados disponível |Descrição |
|-------------------|-----------------------------|
| **cat** | Nesta tabela esta disponível todas as raça consultadas na API
| **cat_image** | Imagens relacionadas a raça carregada na base
| **temperament** | Todos os temperamentos relacionados em nossa base
| **cat_temperament** | Todos os temperamentos relacionados e normatizados por raças


**Processo para realização de teste caso necessário** 
*processo de limpeza de dados para construção de dados* 
###### processo de eliminação de tabelas  

 - drop table public.cat; 
 - drop table public.cat_image; 
 - drop table public.cat_temperament; 
 - drop table public.temperament;


### Processo para consulta de dados carregados nas tabelas

 - SELECT * FROM cat;
 -  SELECT id, name_cat name FROM cat; 
 - SELECT *  FROM cat_image; 
 - SELECT * FROM cat_image where id in (select id from cat) 
 -  SELECT *  FROM  cat_image where id = 'abys'; 
 -  SELECT category_id, count(1)  FROM cat_image group by category_id;
 - SELECT id_temperament, temperament	FROM public.temperament;
 -  SELECT id_temperament,count(1) total FROM cat_temperament group by
   id_temperament ;
   - SELECT * FROM cat where (upper(origin) = 'EGPYPT' or country_code =
   'EG')
   - SELECT * FROM cat where (upper(origin) = upper('EG') or country_code = upper('EG'))
   - SELECT * FROM cat where id in (select id from cat_temperament where upper(id_temperament) = 'INTELLIGENT' ) order by name_cat 
   - SELECT * FROM cat where (upper(origin) = upper('Egypt') or upper(country_code) = upper('EGPYPT')) 
   - select origin, count(1) total from cat group by origin order by 1
