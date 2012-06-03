-- Table: tblrentaloutstanding

-- DROP TABLE tblrentaloutstanding;

CREATE TABLE tblrentaloutstanding
(
  rentalid uuid,
  outstanding numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblrentaloutstanding
  OWNER TO dny;
