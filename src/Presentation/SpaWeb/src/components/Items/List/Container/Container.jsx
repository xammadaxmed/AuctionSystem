import React, { Fragment, useRef, useCallback } from "react";
import { Row, Col, Card, Spinner } from "react-bootstrap";
import { Link } from "react-router-dom";
import { itemDetailsSlug } from "../../../../utils/helpers/slug";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCaretRight } from "@fortawesome/free-solid-svg-icons";
import "./Container.css";

export const Container = ({
  loading,
  hasMore,
  setPageNumber,
  items,
  error,
}) => {
  const observer = useRef();
  const lastItemElementRef = useCallback(
    (node) => {
      if (loading) return;
      if (observer.current) observer.current.disconnect();
      observer.current = new IntersectionObserver((entries) => {
        if (entries[0].isIntersecting && hasMore) {
          setPageNumber((prevPageNumber) => prevPageNumber + 1);
        }
      });
      if (node) observer.current.observe(node);
    },
    [loading, hasMore, setPageNumber]
  );

  return (
    <Fragment>
      <Row>
        {items.length === 0 && !loading ? (
          <h1>No results</h1>
        ) : (
          items.map((item, index) => {
            return (
              <Col key={index} lg={6} sm={6}>
                <Card
                  ref={items.length === index + 1 ? lastItemElementRef : null}
                  className="shadow m-2 floating-card"
                >
                  <Link to={itemDetailsSlug(item.title, item.id)}>
                    <Card.Img
                      height="240px"
                      variant="top"
                      alt="item image"
                      src={item.pictures[0]?.url}
                    />
                  </Link>
                  <Card.Body>
                    <Card.Title>
                      <Link to={itemDetailsSlug(item.title, item.id)}>
                        {item.title}
                      </Link>
                    </Card.Title>
                    <Card.Title>
                      <div className="d-flex">
                        Owner:{" "}
                        <p style={{ color: "grey" }} className="ml-1">
                          {item.userFullName}
                        </p>
                      </div>
                    </Card.Title>

                    <p style={{ color: "grey" }}>
                      Starting price: {process.env.REACT_APP_CURRENCY_SIGN}
                      {item.startingPrice}
                    </p>
                    <Link to={itemDetailsSlug(item.title, item.id)}>
                      <span className="float-right" style={{ color: "red" }}>
                        Bid now <FontAwesomeIcon icon={faCaretRight} />
                      </span>
                    </Link>
                  </Card.Body>
                </Card>
              </Col>
            );
          })
        )}
      </Row>
      {loading ? (
        <div className="ml-5 pt-3 pb-3">
          Loading...
          <Spinner animation="border" />
        </div>
      ) : (
        ""
      )}
      {error ?? "error happened"}
    </Fragment>
  );
};
