import ddpClient from '../services/ddpClient'

function get(id) {
    return ddpClient.get('domains/' + id)
}

function getAll() {
    throw new Error("NYI");
}
function add(name) {
    return ddpClient.post('domains/', { name: name });
}
export default {
    get,
    getAll,
    add
}