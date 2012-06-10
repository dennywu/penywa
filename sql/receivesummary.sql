CREATE TABLE tblreceivesummary
(
  receiveid uuid,
  total numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblreceivesummary
  OWNER TO postgres;
