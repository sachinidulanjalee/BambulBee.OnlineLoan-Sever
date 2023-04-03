import http from "../common/http-common";

const create = (data) => {
  return http.post("LendingDetails", data);
};

const update = (data) => {
  return http.put("LendingDetails", data);
};

const getAll = () => {
  return http.get("LendingDetails");
};

const get = (id) => {
  return http.get(`LendingDetails/${id}`);
};

const remove = (id) => {
  return http.delete(`LendingDetails/${id}`);
};

// eslint-disable-next-line
export default {
  create,
  update,
  getAll,
  get,
  remove,
};
