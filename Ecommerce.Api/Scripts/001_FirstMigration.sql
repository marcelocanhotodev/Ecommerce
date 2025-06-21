CREATE TABLE IF NOT EXISTS public.products
(
    id BIGSERIAL PRIMARY KEY,
    ean VARCHAR(100) NOT NULL,
    brandid BIGINT NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    createdat TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updatedat TIMESTAMP
);
CREATE TABLE IF NOT EXISTS public.participants
(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    document VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(50) NOT NULL,
    createdat TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updatedat TIMESTAMP
);

CREATE TABLE IF NOT EXISTS public.orders
(
    id BIGSERIAL PRIMARY KEY,
    participantid bigint NOT NULL,
    date timestamp without time zone NOT NULL,
    total numeric(18,2) NOT NULL,
    CONSTRAINT fk_order_participant FOREIGN KEY (participantid)
        REFERENCES public.participants (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS public.order_items
(
    id BIGSERIAL PRIMARY KEY,
    orderid bigint NOT NULL,
    productid bigint NOT NULL,
    quantity integer NOT NULL,
    unitprice numeric(18,2) NOT NULL,
    totalitem numeric(18,2) NOT NULL,
    CONSTRAINT fk_orderitem_order FOREIGN KEY (orderid)
        REFERENCES public.orders (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT fk_orderitem_product FOREIGN KEY (productid)
        REFERENCES public.products (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
