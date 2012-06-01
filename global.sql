--
-- PostgreSQL database dump
--

-- Dumped from database version 9.1.1
-- Dumped by pg_dump version 9.1.1
-- Started on 2012-06-01 18:49:53

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 167 (class 3079 OID 11638)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 1877 (class 0 OID 0)
-- Dependencies: 167
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 164 (class 1259 OID 16422)
-- Dependencies: 5
-- Name: tblcustomer; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tblcustomer (
    id integer NOT NULL,
    name character varying(255),
    alamat character varying(255),
    kota character varying(255),
    negara character varying(255),
    kodepos character varying(255),
    email character varying(255),
    outstanding numeric
);


ALTER TABLE public.tblcustomer OWNER TO postgres;

--
-- TOC entry 163 (class 1259 OID 16420)
-- Dependencies: 5 164
-- Name: tblcustomer_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tblcustomer_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tblcustomer_id_seq OWNER TO postgres;

--
-- TOC entry 1878 (class 0 OID 0)
-- Dependencies: 163
-- Name: tblcustomer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tblcustomer_id_seq OWNED BY tblcustomer.id;


--
-- TOC entry 1879 (class 0 OID 0)
-- Dependencies: 163
-- Name: tblcustomer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tblcustomer_id_seq', 2, true);


--
-- TOC entry 166 (class 1259 OID 16448)
-- Dependencies: 5
-- Name: tblitem; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tblitem (
    itemid bigint NOT NULL,
    name character varying(255),
    deskripsi character varying(255),
    harga numeric,
    status character varying(255),
    dendaperhari numeric
);


ALTER TABLE public.tblitem OWNER TO postgres;

--
-- TOC entry 165 (class 1259 OID 16446)
-- Dependencies: 166 5
-- Name: tblitem_itemid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tblitem_itemid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tblitem_itemid_seq OWNER TO postgres;

--
-- TOC entry 1880 (class 0 OID 0)
-- Dependencies: 165
-- Name: tblitem_itemid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tblitem_itemid_seq OWNED BY tblitem.itemid;


--
-- TOC entry 1881 (class 0 OID 0)
-- Dependencies: 165
-- Name: tblitem_itemid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tblitem_itemid_seq', 3, true);


--
-- TOC entry 162 (class 1259 OID 16411)
-- Dependencies: 5
-- Name: tbluser; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tbluser (
    userid integer NOT NULL,
    username character varying(255),
    password character varying(255)
);


ALTER TABLE public.tbluser OWNER TO postgres;

--
-- TOC entry 161 (class 1259 OID 16409)
-- Dependencies: 162 5
-- Name: user_userid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE user_userid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_userid_seq OWNER TO postgres;

--
-- TOC entry 1882 (class 0 OID 0)
-- Dependencies: 161
-- Name: user_userid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE user_userid_seq OWNED BY tbluser.userid;


--
-- TOC entry 1883 (class 0 OID 0)
-- Dependencies: 161
-- Name: user_userid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('user_userid_seq', 1, true);


--
-- TOC entry 1861 (class 2604 OID 16425)
-- Dependencies: 163 164 164
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tblcustomer ALTER COLUMN id SET DEFAULT nextval('tblcustomer_id_seq'::regclass);


--
-- TOC entry 1862 (class 2604 OID 16451)
-- Dependencies: 165 166 166
-- Name: itemid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tblitem ALTER COLUMN itemid SET DEFAULT nextval('tblitem_itemid_seq'::regclass);


--
-- TOC entry 1860 (class 2604 OID 16414)
-- Dependencies: 162 161 162
-- Name: userid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tbluser ALTER COLUMN userid SET DEFAULT nextval('user_userid_seq'::regclass);


--
-- TOC entry 1870 (class 0 OID 16422)
-- Dependencies: 164
-- Data for Name: tblcustomer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tblcustomer (id, name, alamat, kota, negara, kodepos, email, outstanding) FROM stdin;
2	Apin	gak tau tuh	Batam	Indonesia	21432	denny@inforsys.co.id	0
1	Dennya	aaaa	Batam	Indonesia	21432	denny@inforsys.co.id	0
\.


--
-- TOC entry 1871 (class 0 OID 16448)
-- Dependencies: 166
-- Data for Name: tblitem; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tblitem (itemid, name, deskripsi, harga, status, dendaperhari) FROM stdin;
2	test	buatan bandung	1000	Aktif	\N
1	Mesin Rumput	buatan bandung	500000	Aktif	300000
3	a	a	34343	Aktif	3434
\.


--
-- TOC entry 1869 (class 0 OID 16411)
-- Dependencies: 162
-- Data for Name: tbluser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tbluser (userid, username, password) FROM stdin;
1	test	test
\.


--
-- TOC entry 1866 (class 2606 OID 16430)
-- Dependencies: 164 164
-- Name: tblcustomer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tblcustomer
    ADD CONSTRAINT tblcustomer_pkey PRIMARY KEY (id);


--
-- TOC entry 1868 (class 2606 OID 16456)
-- Dependencies: 166 166
-- Name: tblitem_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tblitem
    ADD CONSTRAINT tblitem_pkey PRIMARY KEY (itemid);


--
-- TOC entry 1864 (class 2606 OID 16419)
-- Dependencies: 162 162
-- Name: user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tbluser
    ADD CONSTRAINT user_pkey PRIMARY KEY (userid);


--
-- TOC entry 1876 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2012-06-01 18:49:54

--
-- PostgreSQL database dump complete
--

