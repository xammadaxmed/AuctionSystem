import { useEffect, useState, useCallback } from "react";
import itemsService from "../../services/itemsService";

const useItemsSearch = (query, pageNumber, setPageNumber) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(false);
  const [items, setItems] = useState([]);
  const [totalItemsCount, setTotalItemsCount] = useState(0);
  const [hasMore, setHasMore] = useState(false);

  useEffect(() => {
    setItems([]);
    setPageNumber(1);
  }, [query, setPageNumber]);

  const makeRequest = useCallback(() => {
    setLoading(true);
    setError(false);

    query.pageNumber = pageNumber;
    query.pageSize = 10;

    itemsService
      .getItems(query)
      .then((result) => {
        setItems((previtems) => {
          return [...previtems, ...result.data.data];
        });
        setTotalItemsCount(result.data.totalDataCount);
        setHasMore(
          result.data.totalDataCount > result.data.pageSize &&
            result.data.data.length > 0
        );
        setLoading(false);
      })
      .catch(() => setError(true));
  }, [query, pageNumber]);

  return {
    makeRequest,
    loading,
    error,
    items,
    totalItemsCount,
    hasMore,
  };
};

export default useItemsSearch;
