toc.dat                                                                                             100600  004000  002000  00000016055 11762126726 007323  0                                                                                                    ustar00                                                                                                                                                                                                                                                        PGDMP           8                p            global    9.1.1    9.1.1     P           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false         Q           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false         R           1262    16393    global    DATABASE     �   CREATE DATABASE global WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';
    DROP DATABASE global;
             postgres    false                     2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             postgres    false         S           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                  postgres    false    5         T           0    0    public    ACL     �   REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;
                  postgres    false    5         �            3079    11638    plpgsql 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
    DROP EXTENSION plpgsql;
                  false         U           0    0    EXTENSION plpgsql    COMMENT     @   COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
                       false    167         �            1259    16422    tblcustomer    TABLE       CREATE TABLE tblcustomer (
    id integer NOT NULL,
    name character varying(255),
    alamat character varying(255),
    kota character varying(255),
    negara character varying(255),
    kodepos character varying(255),
    email character varying(255),
    outstanding numeric
);
    DROP TABLE public.tblcustomer;
       public         postgres    false    5         �            1259    16420    tblcustomer_id_seq    SEQUENCE     t   CREATE SEQUENCE tblcustomer_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.tblcustomer_id_seq;
       public       postgres    false    5    164         V           0    0    tblcustomer_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE tblcustomer_id_seq OWNED BY tblcustomer.id;
            public       postgres    false    163         W           0    0    tblcustomer_id_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('tblcustomer_id_seq', 2, true);
            public       postgres    false    163         �            1259    16448    tblitem    TABLE     �   CREATE TABLE tblitem (
    itemid bigint NOT NULL,
    name character varying(255),
    deskripsi character varying(255),
    harga numeric,
    status character varying(255),
    dendaperhari numeric
);
    DROP TABLE public.tblitem;
       public         postgres    false    5         �            1259    16446    tblitem_itemid_seq    SEQUENCE     t   CREATE SEQUENCE tblitem_itemid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.tblitem_itemid_seq;
       public       postgres    false    166    5         X           0    0    tblitem_itemid_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE tblitem_itemid_seq OWNED BY tblitem.itemid;
            public       postgres    false    165         Y           0    0    tblitem_itemid_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('tblitem_itemid_seq', 3, true);
            public       postgres    false    165         �            1259    16411    tbluser    TABLE     �   CREATE TABLE tbluser (
    userid integer NOT NULL,
    username character varying(255),
    password character varying(255)
);
    DROP TABLE public.tbluser;
       public         postgres    false    5         �            1259    16409    user_userid_seq    SEQUENCE     q   CREATE SEQUENCE user_userid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.user_userid_seq;
       public       postgres    false    162    5         Z           0    0    user_userid_seq    SEQUENCE OWNED BY     8   ALTER SEQUENCE user_userid_seq OWNED BY tbluser.userid;
            public       postgres    false    161         [           0    0    user_userid_seq    SEQUENCE SET     6   SELECT pg_catalog.setval('user_userid_seq', 1, true);
            public       postgres    false    161         E           2604    16425    id    DEFAULT     ]   ALTER TABLE tblcustomer ALTER COLUMN id SET DEFAULT nextval('tblcustomer_id_seq'::regclass);
 =   ALTER TABLE public.tblcustomer ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    163    164    164         F           2604    16451    itemid    DEFAULT     ]   ALTER TABLE tblitem ALTER COLUMN itemid SET DEFAULT nextval('tblitem_itemid_seq'::regclass);
 =   ALTER TABLE public.tblitem ALTER COLUMN itemid DROP DEFAULT;
       public       postgres    false    165    166    166         D           2604    16414    userid    DEFAULT     Z   ALTER TABLE tbluser ALTER COLUMN userid SET DEFAULT nextval('user_userid_seq'::regclass);
 =   ALTER TABLE public.tbluser ALTER COLUMN userid DROP DEFAULT;
       public       postgres    false    162    161    162         N          0    16422    tblcustomer 
   TABLE DATA               [   COPY tblcustomer (id, name, alamat, kota, negara, kodepos, email, outstanding) FROM stdin;
    public       postgres    false    164       1870.dat O          0    16448    tblitem 
   TABLE DATA               P   COPY tblitem (itemid, name, deskripsi, harga, status, dendaperhari) FROM stdin;
    public       postgres    false    166       1871.dat M          0    16411    tbluser 
   TABLE DATA               6   COPY tbluser (userid, username, password) FROM stdin;
    public       postgres    false    162       1869.dat J           2606    16430    tblcustomer_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY tblcustomer
    ADD CONSTRAINT tblcustomer_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.tblcustomer DROP CONSTRAINT tblcustomer_pkey;
       public         postgres    false    164    164         L           2606    16456    tblitem_pkey 
   CONSTRAINT     O   ALTER TABLE ONLY tblitem
    ADD CONSTRAINT tblitem_pkey PRIMARY KEY (itemid);
 >   ALTER TABLE ONLY public.tblitem DROP CONSTRAINT tblitem_pkey;
       public         postgres    false    166    166         H           2606    16419 	   user_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY tbluser
    ADD CONSTRAINT user_pkey PRIMARY KEY (userid);
 ;   ALTER TABLE ONLY public.tbluser DROP CONSTRAINT user_pkey;
       public         postgres    false    162    162                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           1870.dat                                                                                            100600  004000  002000  00000000200 11762126726 007116  0                                                                                                    ustar00                                                                                                                                                                                                                                                        2	Apin	gak tau tuh	Batam	Indonesia	21432	denny@inforsys.co.id	0
1	Dennya	aaaa	Batam	Indonesia	21432	denny@inforsys.co.id	0
\.


                                                                                                                                                                                                                                                                                                                                                                                                1871.dat                                                                                            100600  004000  002000  00000000162 11762126726 007126  0                                                                                                    ustar00                                                                                                                                                                                                                                                        2	test	buatan bandung	1000	Aktif	\N
1	Mesin Rumput	buatan bandung	500000	Aktif	300000
3	a	a	34343	Aktif	3434
\.


                                                                                                                                                                                                                                                                                                                                                                                                              1869.dat                                                                                            100600  004000  002000  00000000021 11762126726 007127  0                                                                                                    ustar00                                                                                                                                                                                                                                                        1	test	test
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               restore.sql                                                                                         100600  004000  002000  00000014651 11762126726 010250  0                                                                                                    ustar00                                                                                                                                                                                                                                                        create temporary table pgdump_restore_path(p text);
--
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
-- Edit the following to match the path where the
-- tar archive has been extracted.
--
insert into pgdump_restore_path values('/tmp');

--
-- PostgreSQL database dump
--

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;

ALTER TABLE ONLY public.tbluser DROP CONSTRAINT user_pkey;
ALTER TABLE ONLY public.tblitem DROP CONSTRAINT tblitem_pkey;
ALTER TABLE ONLY public.tblcustomer DROP CONSTRAINT tblcustomer_pkey;
ALTER TABLE public.tbluser ALTER COLUMN userid DROP DEFAULT;
ALTER TABLE public.tblitem ALTER COLUMN itemid DROP DEFAULT;
ALTER TABLE public.tblcustomer ALTER COLUMN id DROP DEFAULT;
DROP SEQUENCE public.user_userid_seq;
DROP TABLE public.tbluser;
DROP SEQUENCE public.tblitem_itemid_seq;
DROP TABLE public.tblitem;
DROP SEQUENCE public.tblcustomer_id_seq;
DROP TABLE public.tblcustomer;
DROP EXTENSION plpgsql;
DROP SCHEMA public;
--
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
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
-- Name: tblcustomer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tblcustomer_id_seq OWNED BY tblcustomer.id;


--
-- Name: tblcustomer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tblcustomer_id_seq', 2, true);


--
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
-- Name: tblitem_itemid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tblitem_itemid_seq OWNED BY tblitem.itemid;


--
-- Name: tblitem_itemid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tblitem_itemid_seq', 3, true);


--
-- Name: tbluser; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tbluser (
    userid integer NOT NULL,
    username character varying(255),
    password character varying(255)
);


ALTER TABLE public.tbluser OWNER TO postgres;

--
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
-- Name: user_userid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE user_userid_seq OWNED BY tbluser.userid;


--
-- Name: user_userid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('user_userid_seq', 1, true);


--
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tblcustomer ALTER COLUMN id SET DEFAULT nextval('tblcustomer_id_seq'::regclass);


--
-- Name: itemid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tblitem ALTER COLUMN itemid SET DEFAULT nextval('tblitem_itemid_seq'::regclass);


--
-- Name: userid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE tbluser ALTER COLUMN userid SET DEFAULT nextval('user_userid_seq'::regclass);


--
-- Data for Name: tblcustomer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tblcustomer (id, name, alamat, kota, negara, kodepos, email, outstanding) FROM stdin;
\.
copy tblcustomer (id, name, alamat, kota, negara, kodepos, email, outstanding)  from '$$PATH$$/1870.dat' ;
--
-- Data for Name: tblitem; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tblitem (itemid, name, deskripsi, harga, status, dendaperhari) FROM stdin;
\.
copy tblitem (itemid, name, deskripsi, harga, status, dendaperhari)  from '$$PATH$$/1871.dat' ;
--
-- Data for Name: tbluser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY tbluser (userid, username, password) FROM stdin;
\.
copy tbluser (userid, username, password)  from '$$PATH$$/1869.dat' ;
--
-- Name: tblcustomer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tblcustomer
    ADD CONSTRAINT tblcustomer_pkey PRIMARY KEY (id);


--
-- Name: tblitem_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tblitem
    ADD CONSTRAINT tblitem_pkey PRIMARY KEY (itemid);


--
-- Name: user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tbluser
    ADD CONSTRAINT user_pkey PRIMARY KEY (userid);


--
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       