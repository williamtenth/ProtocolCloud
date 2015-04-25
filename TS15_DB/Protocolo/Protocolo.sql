CREATE TABLE plantilla_prueba ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	terminado tinyint
)
;

CREATE TABLE pro_ntc1005 ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint,
	icc numeric(10,2),
	ucc numeric(10,2),
	perdidas24 numeric(18,2),
	perdidas85 numeric(18,2),
	garantiazada85 numeric(18,2),
	i2r24 numeric(18,2),
	i2r85 numeric(18,2),
	i2r85garantia numeric(18,2),
	impedancia24 numeric(5,2),
	impedancia85 numeric(5,2),
	impedancia85gar numeric(10,2),
	regulacion numeric(10,4),
	eficiencia numeric(10,4)
)
;

CREATE TABLE pro_ntc1031 ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint,
	ix numeric(4,3),
	i2 numeric(4,3),
	i3 numeric(4,3),
	promedio numeric(4,3),
	garantia numeric(4,3),
	po_medida numeric(5,2),
	po_garantizado numeric(5,2)
)
;

CREATE TABLE pro_ntc1465 ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint,
	tipaislante tinyint,
	refaislante tinyint,
	ruptura numeric(10),
	metaislante tinyint
)
;

CREATE TABLE pro_ntc3396 ( 
	id int NOT NULL,
	transformador_id int NOT NULL,
	proceso_id int,
	fecha datetime NOT NULL,
	resultado tinyint,
	estado bigint,
	color varchar(12),
	salina1 tinyint,
	salina2 tinyint,
	impacto tinyint,
	espesorvalor numeric(5),
	espesor1 tinyint,
	espesor2 tinyint,
	adherencia decimal(5)
)
;

CREATE TABLE pro_ntc375 ( 
	id int NOT NULL,
	transformador_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint,
	tiempolectura numeric(18),
	tension numeric(18,2),
	at_t numeric(10,2),
	bt_t numeric(10,2),
	at_bt_t numeric(10,2),
	resistencia_uv numeric(6,3),
	resistencia_vw numeric(6,3),
	resistencia_wv numeric(6,3),
	resistencia_promedio numeric(6,3),
	resistencia2_uv numeric(6,3),
	resistencia2_vw numeric(6,3),
	resistencia2_wv numeric(6,3),
	resistencia2_promedio numeric(6,3),
	matedevanado tinyint,
	metadevanado2 tinyint
)
;

CREATE TABLE pro_ntc471 ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint,
	relacion varchar(50),
	fase_fase varchar(50),
	fase_neutro varchar(50),
	polaridad varchar(50)
)
;

CREATE TABLE pro_ntc471_has_relacion ( 
	id numeric(10) NOT NULL,
	ntc471_id int,
	consecutivo tinyint,
	tension numeric(18,2),
	fase_u numeric(10,2),
	fase_v numeric(10,2),
	fase_w numeric(10,2),
	nominal numeric(10,2),
	minima numeric(10,2),
	maxima numeric(10,2)
)
;

CREATE TABLE pro_ntc837 ( 
	id int NOT NULL,
	transformador_id int,
	proceso_id int,
	fecha datetime,
	resultado tinyint,
	estado tinyint
)
;

CREATE TABLE pro_proceso ( 
	id int NOT NULL,
	pedido_id int,
	tipprocesop tinyint,
	fecha datetime,
	estado int,
	resultado tinyint,
	tempensayo int,
	posconmutador tinyint
)
;

CREATE TABLE pro_proceso_has_prueba ( 
	proceso_id int NOT NULL,
	pro_prueba_id int NOT NULL,
	fecha datetime,
	resultado tinyint
)
;


ALTER TABLE pro_ntc1005 ADD CONSTRAINT PK_pro_ntc1005 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc1031 ADD CONSTRAINT PK_pro_ntc1031 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc1465 ADD CONSTRAINT PK_pro_ntc1465 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc3396 ADD CONSTRAINT PK_pro_ntc3396 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc375 ADD CONSTRAINT PK_pro_ntc375 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc471 ADD CONSTRAINT PK_pro_ntc471 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_ntc471_has_relacion ADD CONSTRAINT PK_pro_ntc471_relacion 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_proceso ADD CONSTRAINT PK_pro_proceso 
	PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE pro_proceso_has_prueba ADD CONSTRAINT PK_pro_proceso_has_prueba 
	PRIMARY KEY CLUSTERED (proceso_id, pro_prueba_id)
;



ALTER TABLE pro_ntc1005 ADD CONSTRAINT FK_pro_ntc1005_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc1031 ADD CONSTRAINT FK_pro_ntc1031_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc1465 ADD CONSTRAINT FK_pro_ntc1465_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc3396 ADD CONSTRAINT FK_pro_ntc3396_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc375 ADD CONSTRAINT FK_pro_ntc375_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc471 ADD CONSTRAINT FK_pro_ntc471_tfr_transformador 
	FOREIGN KEY (transformador_id) REFERENCES tfr_transformador (id)
;

ALTER TABLE pro_ntc471_has_relacion ADD CONSTRAINT FK_pro_ntc471_has_relacion_pro_ntc471 
	FOREIGN KEY (ntc471_id) REFERENCES pro_ntc471 (id)
;

ALTER TABLE pro_proceso ADD CONSTRAINT FK_pro_proceso_cli_pedido 
	FOREIGN KEY (pedido_id) REFERENCES cli_pedido (id)
;

ALTER TABLE pro_proceso_has_prueba ADD CONSTRAINT FK_pro_proceso_has_prueba_pro_proceso 
	FOREIGN KEY (proceso_id) REFERENCES pro_proceso (id)
;









EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena los resultados de la pruebas de Medición', 'Schema', dbo, 'table', plantilla_prueba
;






EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena la información de la prueba "Determinación y pérdidas con carga" (7) (8) (9).', 'Schema', dbo, 'table', pro_ntc1005
;



















EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena los resultados de la pruebas de "Ensayo sin carga" (6).', 'Schema', dbo, 'table', pro_ntc1031
;













EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena los resultados de la pruebas de Medición "Líquido aislante" (1).', 'Schema', dbo, 'table', pro_ntc1465
;










EXEC sp_addextendedproperty 'MS_Description', 'En esta tabla se almacena la información de la prueba para transformadores "Pintura de tanques para transformador" (12).', 'Schema', dbo, 'table', pro_ntc3396
;














EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena los resultados de la pruebas de Medición de la "Resistencia de aislamiento" (2) (4).', 'Schema', dbo, 'table', pro_ntc375
;




















EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena la información general de la prueba de relación de transformación, verificación de polaridad y relación de fase (3).', 'Schema', dbo, 'table', pro_ntc471
;










EXEC sp_addextendedproperty 'MS_Description', 'Esta tabla almacena el correspondiente voltaje para cada fase (3).', 'Schema', dbo, 'table', pro_ntc471_has_relacion
;










EXEC sp_addextendedproperty 'MS_Description', 'Este tabla almacena los resultados de la pruebas de "Ensayo de aislamiento" (5).', 'Schema', dbo, 'table', pro_ntc837
;






EXEC sp_addextendedproperty 'MS_Description', 'Esta tabla almacena la información de los procesos de pruebas preliminares y de protocolo.', 'Schema', dbo, 'table', pro_proceso
;








EXEC sp_addextendedproperty 'MS_Description', 'Esta tabla permite relacionar las pruebas definidas para un proceso de pruebas preliminares como de protocolo.', 'Schema', dbo, 'table', pro_proceso_has_prueba
;
