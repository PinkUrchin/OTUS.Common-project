PGDMP  8                     {            postgres    16.0 (Debian 16.0-1.pgdg120+1)    16.0 [    o           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            p           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            q           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            r           1262    5    postgres    DATABASE     s   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';
    DROP DATABASE postgres;
                postgres    false            s           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    3442                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                pg_database_owner    false            t           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   pg_database_owner    false    4            �            1259    16388    Countrys    TABLE     ~   CREATE TABLE public."Countrys" (
    id bigint NOT NULL,
    "CountryCode" character(10),
    "CountryName" character(100)
);
    DROP TABLE public."Countrys";
       public         heap    postgres    false    4            u           0    0    TABLE "Countrys"    COMMENT     C   COMMENT ON TABLE public."Countrys" IS 'Таблица стран';
          public          postgres    false    215            v           0    0    COLUMN "Countrys".id    COMMENT     A   COMMENT ON COLUMN public."Countrys".id IS 'Код страны';
          public          postgres    false    215            w           0    0    COLUMN "Countrys"."CountryCode"    COMMENT     L   COMMENT ON COLUMN public."Countrys"."CountryCode" IS 'Код страны';
          public          postgres    false    215            x           0    0    COLUMN "Countrys"."CountryName"    COMMENT     V   COMMENT ON COLUMN public."Countrys"."CountryName" IS 'Название страны';
          public          postgres    false    215            �            1259    16391    Countrys_id_seq    SEQUENCE     �   ALTER TABLE public."Countrys" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Countrys_id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    215            �            1259    16392    Managers    TABLE     �   CREATE TABLE public."Managers" (
    "FirstName" character(100),
    "ID" bigint NOT NULL,
    "LastName" character(100),
    "Email" character(100)
);
    DROP TABLE public."Managers";
       public         heap    postgres    false    4            y           0    0    TABLE "Managers"    COMMENT     `   COMMENT ON TABLE public."Managers" IS 'Таблица менеджеров магазинов';
          public          postgres    false    217            z           0    0    COLUMN "Managers"."FirstName"    COMMENT     P   COMMENT ON COLUMN public."Managers"."FirstName" IS 'Имя менеджера';
          public          postgres    false    217            {           0    0    COLUMN "Managers"."ID"    COMMENT     E   COMMENT ON COLUMN public."Managers"."ID" IS 'ID менеджера';
          public          postgres    false    217            |           0    0    COLUMN "Managers"."Email"    COMMENT     K   COMMENT ON COLUMN public."Managers"."Email" IS 'Email менеджера';
          public          postgres    false    217            �            1259    16395    Managers_ID_seq    SEQUENCE     �   ALTER TABLE public."Managers" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Managers_ID_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    217            �            1259    32785 	   dw_shapes    TABLE     D  CREATE TABLE public.dw_shapes (
    "Id" bigint NOT NULL,
    "ShapeType" smallint NOT NULL,
    "CreateDate" date NOT NULL,
    "UpdateDate" date,
    "CreateAuthor" character(200) NOT NULL,
    "UpdateAuthor" character(200),
    "DocumentId" bigint NOT NULL,
    "Color" character(100),
    "Coords" character(9999999)
);
    DROP TABLE public.dw_shapes;
       public         heap    postgres    false    4            �            1259    32784    Primitive_Id_seq    SEQUENCE     �   ALTER TABLE public.dw_shapes ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Primitive_Id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    229            �            1259    16396    Products    TABLE     V   CREATE TABLE public."Products" (
    id bigint NOT NULL,
    "Name" character(200)
);
    DROP TABLE public."Products";
       public         heap    postgres    false    4            }           0    0    COLUMN "Products".id    COMMENT     =   COMMENT ON COLUMN public."Products".id IS 'ID товара';
          public          postgres    false    219            �            1259    16399    Products_id_seq    SEQUENCE     �   ALTER TABLE public."Products" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Products_id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    219            �            1259    32815    dw_shape_type    TABLE     [   CREATE TABLE public.dw_shape_type (
    "Id" bigint NOT NULL,
    "Name" character(100)
);
 !   DROP TABLE public.dw_shape_type;
       public         heap    postgres    false    4            �            1259    32814    ShapeType_Id_seq    SEQUENCE     �   ALTER TABLE public.dw_shape_type ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ShapeType_Id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    233    4            �            1259    16400    Stocks    TABLE     �   CREATE TABLE public."Stocks" (
    "ID" bigint NOT NULL,
    "Backstore" bigint,
    "Frontstore" bigint,
    "ShoppingWindow" bigint,
    "StockAccuracy" double precision,
    "OnFloorAvailability" double precision,
    "StockMeanAge" bigint
);
    DROP TABLE public."Stocks";
       public         heap    postgres    false    4            ~           0    0    COLUMN "Stocks"."ID"    COMMENT     A   COMMENT ON COLUMN public."Stocks"."ID" IS 'ID остатков';
          public          postgres    false    221                       0    0    COLUMN "Stocks"."Backstore"    COMMENT     F   COMMENT ON COLUMN public."Stocks"."Backstore" IS 'на складе';
          public          postgres    false    221            �           0    0    COLUMN "Stocks"."Frontstore"    COMMENT     I   COMMENT ON COLUMN public."Stocks"."Frontstore" IS 'в магазине';
          public          postgres    false    221            �           0    0     COLUMN "Stocks"."ShoppingWindow"    COMMENT     M   COMMENT ON COLUMN public."Stocks"."ShoppingWindow" IS 'на витрине';
          public          postgres    false    221            �           0    0    COLUMN "Stocks"."StockAccuracy"    COMMENT     V   COMMENT ON COLUMN public."Stocks"."StockAccuracy" IS 'точность запаса';
          public          postgres    false    221            �           0    0 %   COLUMN "Stocks"."OnFloorAvailability"    COMMENT     e   COMMENT ON COLUMN public."Stocks"."OnFloorAvailability" IS 'доступность на этаже';
          public          postgres    false    221            �           0    0    COLUMN "Stocks"."StockMeanAge"    COMMENT     k   COMMENT ON COLUMN public."Stocks"."StockMeanAge" IS 'Запас - средний возраст (дни)';
          public          postgres    false    221            �            1259    16403    Stocks_ID_seq    SEQUENCE     �   ALTER TABLE public."Stocks" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Stocks_ID_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    221            �            1259    16404    Store_Product_Stock    TABLE     �   CREATE TABLE public."Store_Product_Stock" (
    id bigint NOT NULL,
    store_id bigint,
    product_id bigint,
    stock_id bigint
);
 )   DROP TABLE public."Store_Product_Stock";
       public         heap    postgres    false    4            �           0    0 %   COLUMN "Store_Product_Stock".store_id    COMMENT     R   COMMENT ON COLUMN public."Store_Product_Stock".store_id IS 'id магазина';
          public          postgres    false    223            �           0    0 '   COLUMN "Store_Product_Stock".product_id    COMMENT     i   COMMENT ON COLUMN public."Store_Product_Stock".product_id IS 'id продукта (категории)';
          public          postgres    false    223            �           0    0 %   COLUMN "Store_Product_Stock".stock_id    COMMENT     a   COMMENT ON COLUMN public."Store_Product_Stock".stock_id IS 'id склада (остатков)';
          public          postgres    false    223            �            1259    16407    Store_Product_Stock_id_seq    SEQUENCE     �   ALTER TABLE public."Store_Product_Stock" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Store_Product_Stock_id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    223            �            1259    16408    Stores    TABLE     �   CREATE TABLE public."Stores" (
    id bigint NOT NULL,
    "Name" character(200) NOT NULL,
    "Email" character(100),
    "Country" bigint,
    "Manager" bigint
);
    DROP TABLE public."Stores";
       public         heap    postgres    false    4            �           0    0    TABLE "Stores"    COMMENT     I   COMMENT ON TABLE public."Stores" IS 'Таблица магазинов';
          public          postgres    false    225            �           0    0    COLUMN "Stores".id    COMMENT     ?   COMMENT ON COLUMN public."Stores".id IS 'Id магазина';
          public          postgres    false    225            �           0    0    COLUMN "Stores"."Name"    COMMENT     Q   COMMENT ON COLUMN public."Stores"."Name" IS 'Название магазина';
          public          postgres    false    225            �           0    0    COLUMN "Stores"."Email"    COMMENT     G   COMMENT ON COLUMN public."Stores"."Email" IS 'Email магазины';
          public          postgres    false    225            �            1259    16411    Store_id_seq    SEQUENCE     �   ALTER TABLE public."Stores" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Store_id_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    225            �            1259    32800    dw_documents    TABLE     �   CREATE TABLE public.dw_documents (
    "Id" bigint NOT NULL,
    "Name" character(200),
    "CreateDate" date NOT NULL,
    "CreateAuthor" character(200) NOT NULL,
    "UpdateDate" date,
    "UpdateAuthor" character(200)
);
     DROP TABLE public.dw_documents;
       public         heap    postgres    false    4            �            1259    32799    dw_documents_id_seq    SEQUENCE     �   ALTER TABLE public.dw_documents ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.dw_documents_id_seq
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1
);
            public          postgres    false    4    231            �            1259    24582    points_id_seq    SEQUENCE     z   CREATE SEQUENCE public.points_id_seq
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 9999999
    CACHE 1;
 $   DROP SEQUENCE public.points_id_seq;
       public          postgres    false    4            Z          0    16388    Countrys 
   TABLE DATA           F   COPY public."Countrys" (id, "CountryCode", "CountryName") FROM stdin;
    public          postgres    false    215   rb       \          0    16392    Managers 
   TABLE DATA           L   COPY public."Managers" ("FirstName", "ID", "LastName", "Email") FROM stdin;
    public          postgres    false    217   �b       ^          0    16396    Products 
   TABLE DATA           0   COPY public."Products" (id, "Name") FROM stdin;
    public          postgres    false    219   Vk       `          0    16400    Stocks 
   TABLE DATA           �   COPY public."Stocks" ("ID", "Backstore", "Frontstore", "ShoppingWindow", "StockAccuracy", "OnFloorAvailability", "StockMeanAge") FROM stdin;
    public          postgres    false    221   �k       b          0    16404    Store_Product_Stock 
   TABLE DATA           S   COPY public."Store_Product_Stock" (id, store_id, product_id, stock_id) FROM stdin;
    public          postgres    false    223   �o       d          0    16408    Stores 
   TABLE DATA           M   COPY public."Stores" (id, "Name", "Email", "Country", "Manager") FROM stdin;
    public          postgres    false    225   jq       j          0    32800    dw_documents 
   TABLE DATA           p   COPY public.dw_documents ("Id", "Name", "CreateDate", "CreateAuthor", "UpdateDate", "UpdateAuthor") FROM stdin;
    public          postgres    false    231   �v       l          0    32815    dw_shape_type 
   TABLE DATA           5   COPY public.dw_shape_type ("Id", "Name") FROM stdin;
    public          postgres    false    233   �v       h          0    32785 	   dw_shapes 
   TABLE DATA           �   COPY public.dw_shapes ("Id", "ShapeType", "CreateDate", "UpdateDate", "CreateAuthor", "UpdateAuthor", "DocumentId", "Color", "Coords") FROM stdin;
    public          postgres    false    229   Hw       �           0    0    Countrys_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Countrys_id_seq"', 0, true);
          public          postgres    false    216            �           0    0    Managers_ID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Managers_ID_seq"', 75, true);
          public          postgres    false    218            �           0    0    Primitive_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Primitive_Id_seq"', 0, false);
          public          postgres    false    228            �           0    0    Products_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Products_id_seq"', 12, true);
          public          postgres    false    220            �           0    0    ShapeType_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."ShapeType_Id_seq"', 3, true);
          public          postgres    false    232            �           0    0    Stocks_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Stocks_ID_seq"', 75, true);
          public          postgres    false    222            �           0    0    Store_Product_Stock_id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public."Store_Product_Stock_id_seq"', 89, true);
          public          postgres    false    224            �           0    0    Store_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Store_id_seq"', 75, true);
          public          postgres    false    226            �           0    0    dw_documents_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.dw_documents_id_seq', 0, false);
          public          postgres    false    230            �           0    0    points_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.points_id_seq', 0, false);
          public          postgres    false    227            �           2606    16413    Countrys Countrys_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Countrys"
    ADD CONSTRAINT "Countrys_pkey" PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."Countrys" DROP CONSTRAINT "Countrys_pkey";
       public            postgres    false    215            �           2606    16415    Managers Managers_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Managers"
    ADD CONSTRAINT "Managers_pkey" PRIMARY KEY ("ID");
 D   ALTER TABLE ONLY public."Managers" DROP CONSTRAINT "Managers_pkey";
       public            postgres    false    217            �           2606    32789    dw_shapes Primitive_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.dw_shapes
    ADD CONSTRAINT "Primitive_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public.dw_shapes DROP CONSTRAINT "Primitive_pkey";
       public            postgres    false    229            �           2606    16417    Products Products_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Products_pkey" PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "Products_pkey";
       public            postgres    false    219            �           2606    32819    dw_shape_type ShapeType_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.dw_shape_type
    ADD CONSTRAINT "ShapeType_pkey" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public.dw_shape_type DROP CONSTRAINT "ShapeType_pkey";
       public            postgres    false    233            �           2606    16419    Stocks Stocks_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Stocks"
    ADD CONSTRAINT "Stocks_pkey" PRIMARY KEY ("ID");
 @   ALTER TABLE ONLY public."Stocks" DROP CONSTRAINT "Stocks_pkey";
       public            postgres    false    221            �           2606    16421 ,   Store_Product_Stock Store_Product_Stock_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."Store_Product_Stock"
    ADD CONSTRAINT "Store_Product_Stock_pkey" PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public."Store_Product_Stock" DROP CONSTRAINT "Store_Product_Stock_pkey";
       public            postgres    false    223            �           2606    16423    Stores Store_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public."Stores"
    ADD CONSTRAINT "Store_pkey" PRIMARY KEY (id);
 ?   ALTER TABLE ONLY public."Stores" DROP CONSTRAINT "Store_pkey";
       public            postgres    false    225            �           2606    32804    dw_documents dw_documents_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.dw_documents
    ADD CONSTRAINT dw_documents_pkey PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public.dw_documents DROP CONSTRAINT dw_documents_pkey;
       public            postgres    false    231            �           1259    16424    fki_country_pkey    INDEX     J   CREATE INDEX fki_country_pkey ON public."Stores" USING btree ("Country");
 $   DROP INDEX public.fki_country_pkey;
       public            postgres    false    225            �           1259    16425    fki_manager_key    INDEX     I   CREATE INDEX fki_manager_key ON public."Stores" USING btree ("Manager");
 #   DROP INDEX public.fki_manager_key;
       public            postgres    false    225            �           1259    16426    fki_product_key    INDEX     W   CREATE INDEX fki_product_key ON public."Store_Product_Stock" USING btree (product_id);
 #   DROP INDEX public.fki_product_key;
       public            postgres    false    223            �           1259    16427    fki_stock_id    INDEX     R   CREATE INDEX fki_stock_id ON public."Store_Product_Stock" USING btree (stock_id);
     DROP INDEX public.fki_stock_id;
       public            postgres    false    223            �           1259    16428    fki_stock_key    INDEX     S   CREATE INDEX fki_stock_key ON public."Store_Product_Stock" USING btree (stock_id);
 !   DROP INDEX public.fki_stock_key;
       public            postgres    false    223            �           1259    16429    fki_store_key    INDEX     S   CREATE INDEX fki_store_key ON public."Store_Product_Stock" USING btree (store_id);
 !   DROP INDEX public.fki_store_key;
       public            postgres    false    223            �           2606    32820    dw_shapes ShapeType_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.dw_shapes
    ADD CONSTRAINT "ShapeType_fkey" FOREIGN KEY ("ShapeType") REFERENCES public.dw_shape_type("Id") NOT VALID;
 D   ALTER TABLE ONLY public.dw_shapes DROP CONSTRAINT "ShapeType_fkey";
       public          postgres    false    229    233    3267            �           2606    16430    Stores country_key    FK CONSTRAINT     �   ALTER TABLE ONLY public."Stores"
    ADD CONSTRAINT country_key FOREIGN KEY ("Country") REFERENCES public."Countrys"(id) ON UPDATE SET NULL ON DELETE SET NULL;
 >   ALTER TABLE ONLY public."Stores" DROP CONSTRAINT country_key;
       public          postgres    false    3245    215    225            �           0    0 "   CONSTRAINT country_key ON "Stores"    COMMENT     ^   COMMENT ON CONSTRAINT country_key ON public."Stores" IS 'ключ таблицы стран';
          public          postgres    false    3271            �           2606    32807    dw_shapes document_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.dw_shapes
    ADD CONSTRAINT document_fkey FOREIGN KEY ("DocumentId") REFERENCES public.dw_documents("Id") NOT VALID;
 A   ALTER TABLE ONLY public.dw_shapes DROP CONSTRAINT document_fkey;
       public          postgres    false    229    231    3265            �           2606    16435    Stores manager_key    FK CONSTRAINT     �   ALTER TABLE ONLY public."Stores"
    ADD CONSTRAINT manager_key FOREIGN KEY ("Manager") REFERENCES public."Managers"("ID") ON UPDATE SET NULL ON DELETE SET NULL;
 >   ALTER TABLE ONLY public."Stores" DROP CONSTRAINT manager_key;
       public          postgres    false    225    3247    217            �           2606    16440    Store_Product_Stock product_key    FK CONSTRAINT     �   ALTER TABLE ONLY public."Store_Product_Stock"
    ADD CONSTRAINT product_key FOREIGN KEY (product_id) REFERENCES public."Products"(id) ON UPDATE CASCADE ON DELETE CASCADE;
 K   ALTER TABLE ONLY public."Store_Product_Stock" DROP CONSTRAINT product_key;
       public          postgres    false    219    223    3249            �           2606    16445    Store_Product_Stock stock_id    FK CONSTRAINT     �   ALTER TABLE ONLY public."Store_Product_Stock"
    ADD CONSTRAINT stock_id FOREIGN KEY (stock_id) REFERENCES public."Stocks"("ID") ON UPDATE CASCADE ON DELETE CASCADE;
 H   ALTER TABLE ONLY public."Store_Product_Stock" DROP CONSTRAINT stock_id;
       public          postgres    false    223    221    3251            �           2606    16450    Store_Product_Stock store_key    FK CONSTRAINT     �   ALTER TABLE ONLY public."Store_Product_Stock"
    ADD CONSTRAINT store_key FOREIGN KEY (store_id) REFERENCES public."Stores"(id) ON UPDATE CASCADE ON DELETE CASCADE;
 I   ALTER TABLE ONLY public."Store_Product_Stock" DROP CONSTRAINT store_key;
       public          postgres    false    3259    223    225            Z   #   x�3�tqU�N��Ғ�䌜ļZ�=... �~      \   �  x���KW�<���_��>�}������$���v�-Z��|�4�~$>��Y���a��qQ*�u�>y.
�'�E�tS׮�BfǑr*ۗ^�-rW�I�Xy�����E�]WA���"d�.ם�v���I�}�b��$�G�fpL�#%���5Z-�/g�$l-�K����֠��&�R�-UQr7��L.l���	��V��Y�Ũr��$���Zp?;$�ꌁ{ؚ>)�+5�cwe-�ba����'��k6
��i_���t�dƕ�-yU�H9�o�Ϣ-]+��y)[�WacBDE0حG��茞z�T&x3S��3Y�n� �]9����CZY0&Fʹ��#�<���A�}�8�'�*Oȷ��d����� �er�Fw�b��])k�NFu0S�d�聟]���fK��{�����g�b�A#��)|���Y
���~���a�bK�d�|��H)�����ܶ��5*F��H�賲���]����2?�啮����|�}�46(�z�+��`�u�����:��h��,�Wej��CbC_��������v���*PU,�J��G�mî�Ł��r®�(�|�K�!u���\'�3�����`�=�-��_cp��A�5:I"qNWU�1�^MM�Fy��V�!�,f����ygt����)}Ѷ`�4惲�����˒;�5[���4h����Q,�z��#+�v�����\E�K���n�T)�)��9�1�b��w I��{��^����(VZ5@�~�ؓvY�ΐ�=�"�p��6��g"Z�٢�7kN��_OL����Xc%,u�����H�v��Ϯ������	��)�]�6�(/H�]����S��ϪsX	K��(^v�W��m^!|���r�gtSh��ח�!j�����8Wg���&%��ex#)=������IT��(�p�C^�e���?�$t�R�����U�M��|�Ч�R�����L|)��Wr�C�u��C��})��̋&$^�W�O,Z.�{�aM�7N3L�_2��yl��?�\=���h��O���d�H9ʠ*p��W9~W�������k�M�Wi���D�Gts?Xl��?�5�"N�ݷ/�l�$�rK��n���1S�!d����[�tbi�
vyF��?[�1��\���������)+�j�<��=�]Ujډ"����"�=x�_���z�>ş��cY����u�9/�[�����{���Fe7Q�Z�Ε!c�o�ч~�X"�)�"#WL�����.���W��c�>b(�F��J��P�>y�Z+���VtU�´��P�Pę|֪��̚,��l����t�6���aH:�E��{����Q����jC�
�����ꅒq��yͶ0�[-���Ge�ؖ���x�ȉH����h�7z^�<VZ��x�X����B����꼘("�N�|Q�a1�w'��R
;�KmK����H��[؍��|:�O颭ꐏ)Q�"X���\��we+��5��Ԧ��0d����;E��rs���Od�ke>�NC���wQ�:W�"J�2�w�h��fMɓ[�Z^�:h� .��֋J�مe��W� O��z|�fp�~e�s��[v��2�f��Y��K���֙y��g���J�9Xpmt����;�
\��K�����V��cqv޹�U;xgd���>�m1�&�0�m���볱>�9�޲#_�QD-�-4�����H�/��IR��y����wx���"�g|�n�/\��a��3'�9�G5�]9dI>R��u7�f{.�?�˿-ڈ�.�*xu<��6PD#]3聣X�ǿu���<�~Bn?Rċܩ��j��;����-���͒.~�Aߵ�ZM���W�+�G_�͊.����*a�"��"� �^_w<����Я��6k�u�u��I��H��d�'�1W��؁K�l�֫�(�����E�2�e�|ǳ��0>�ӹ��t�6[��y�� %,�w�d0T����u��3+�3}�9�KV5��N��&�8Het�2���t�C�+7����������&��%�c��x�&�g�N?�m��}�<l4�HG���g�z�{IW��+�ʫ�����@��=�Z�j�ۂ�4�>�M�{I���+K~�������z[�_�.C�40Z*S��(������u|�I�튞�8�Ou��DIS�d��q%�Z��c�bk�[V6������KyІ�T��"I�� x���      ^   }   x�Օ��0�j<py|؅z8��3�.|�R�Ԝױ?�ݦ�nL	��z��nL�."�2�]D01er�� 3%�]DP�R�."��2�]D�0eq�� ����������#��G����xN&f�      `   �  x�E�]�,!��u1s�p/w��_��~�3]��ӊMeƚe����X<#�X�Vb��3�X�u��9��U�q�N9z;�gٵ�ث�|�z���W�VG9T�0���mz�**o:[��z=��UT�7>��QU�7q�L�x�Ap�M�t4+��a�3��,8��M�}F
��}4��2�1�M�"�+��N����v8��	��e'�eU�� ��<��I���(KHg#mv���^1G�͒XF�n�QX9@��E�l#�g���h�>)3�z�Y��͆���>�F�, >e� ����G�kP��3�n!@H8��6.q��N�j�I7��M
��[�ЄWE�<C���9���'㩬3��/w,?	]��v*�n��V��.�t!j��K�g/ ��GLe�YT�3� r�c��Pt��qєq}��q���k2�P��='%�\ܵ�jGy�̴�3@����/qNK�F�ŏ_DWszށ`_H��)��t���a�m���\�\C�Ҹ��̗����re?���K�N�� ���B��!�F+��w�����Y���]m����3��x�:��&��ϕL�,��'��h���BlJ�������<�����|�[�O�2iL�H��o�iFG����Uظ��[�B��pm��9��� �����C<��N�]�}v�_]E �'���i����<���۰�x����@������XoΊJ��w
�z�U4d�Ἂ.�i������2	����Eޯ3ϝ2�=�.䴣�|�>ϒW��P�t_���ԥbh36�˫��K�*2��=C��b���:ך�no+D�#�'�cW�!�	,C!(��h�;
��)	�,���0��V��>�q=w���U,ҁ�*�w+m����aa$���8<��6�@�k��y^Gkw��x>n���n��X%��#+��z��f֝z�*�5�ؕz��Y�lҊ玿+!'A�"����p/���N��Wk���c�      b   �  x�R٭e1��Ō;���_��WQ"��}�}�67^�X/|-�$��l���<��<�C�"�C�=�=D�c�U�;b�Cn hS��8�Rn!��@���&��0a�a.(?d)�}Ȳ���m��4H~�r�Ԙ��3�c���H����,��r�Ţ�H�?�iOч*K����.E�Bn���O�D��вPT�U���H��IVR��Rhyh$d>4���M�,+G�\�U�IV�U�9+�U�I��6�d�[��B�ń����0 �z�2���p�3Fr|
'�JHɖ
���-GcIVKԃe����2�E�òXh��$�[�K�.ױ������`IV�Ma9v�6�c�����|������s8��}8���[+%�qc+���jn���Uo[���?��r�      d   h  x�ݜ�n�F��3O�c{	�I�׉�:���/����S��$���oz�.)���+���;�����3�;dW��Y��"t�@~Y��n�7�rO�D����/����raA�r�tx)V;[�`b�$Ԯqp{���o�ב�ԲE�@	�)7��f��d�P@��IT�n�zk�gak ��L����KU�|]�����%	�m�5�1\���7�z�O����=�1�w��	�)v�#q�%���9�v�5�{�"��͞����'��������3��� �1d�wEQ~�n�Ӫ!N�#����K~�9�P�&�I�n�j]{B�D��\��fmR�@ȓ(S�4<4OO��&'2��f�id1\e6�߅�ab Į��c��n�Sl�Y�m�Uu��Ǣ'!��R���W����cL��v��9�O�@��,�<ڃ��!���Σb;�P�Ƒx�l�4�w��
�%�ؼ��c�?�zB�\�D�|����ms�^��n� ��$$ε�)���i�j��f��j{B�L[�4�~��}��ϣ^����1�ޚ�i'�@�;x� O�ַpן\�]OQD���]��Ř��LjA菩D����k;�Bw ���C����a��]��z���G!ཱིYw��f������?�z�*
	/K�z=��:��gQ!Q(�[Z�3M� ��1B����u�k��B�i1�s~���.�z�	j�E�eU�3x��Aȳh��w���?��:�Я�e�lCO�� �+TF(�f�-��e��y�H��k}c(��}��-�:�	:x�Q��41�N�L�X[��ova���$�A
��Ch�߲m�3�J�~q�C��\_���J�R�粮�&�ez!��J�W�g�U �]��(c��׶��.[B�RP�2���0ǜ=v��uAB�[�2�/e�3(w{�}6����uE�E�� ���P1��6UEabA&p�������6���4�*�J��q��6�з'��D*	��稜�= ĮIT
��;3� � �]�
��ߊm��`�^�к�Q��pxq���j��䙄�bS1��|3�%�@��l	�����wZrЉd��-E�_y�{E�Z�-��sjw��-����?�҃ЮQ�Pw�A�t�\5���Q��)��^u@�]�%������.H�}��۷��ڕOc_r�A���B�};�zl7�B����y�ku�5��t/@h?��N�\�vsYg���N�oYn��l7a�XՃ��Vպ�b�{�C�,����6�����u)�3_�]�PN�c��{��d�题c,�O����������޹܄_wt��G�&J��"�����      j      x������ � �      l   9   x�3����+Q�-�2����K��-
\F@��T�����cNל�̂b�z�+F��� 4A:#      h      x������ � �     