
const Component = {
  data() {
    return {    
      loading: false,
      index: 0,
      productModel: {
        id: 0,
        name: "Product Name",
        description: "Product Description",
        value: 0        
      },
      products: []
    }
  },
  mounted() {
    this.getProducts();
  },
  methods: {
    getProduct(id) {
      this.loading = true;
      axios.get('/Admin/products/' + id)
        .then(res =>{
          console.log(res);
          var product = res.data;
          this.productModel = {
            id: product.id,
            name: product.name,
            description: product.description,
            value: product.value,
          }
        })
        .catch(err => {
          console.log(err);
        })
        .then(() => {
          this.loading = false;
        })
    },
    getProducts() {
      this.loading = true;
      axios.get('/Admin/products')
        .then(res =>{
          console.log(res);
          this.products = res.data;
        })
        .catch(err => {
          console.log(err);
        })
        .then(() => {
          this.loading = false;
        })
    },
    createProduct() {
      this.loading = true;
      axios.post('/Admin/products', this.productModel)
        .then(res => {
          console.log(res);
          this.products.push(res.data);
        })
        .catch(err => {
          console.log(err);
        })
        .then(() => {
          this.loading = false;
        })
    },
    editProduct(id, index) {      
      this.index = index;
      this.getProduct(id);
    },
    updateProduct() {
      this.loading = true;
      axios.put('/Admin/products', this.productModel)
        .then(res => {
          console.log(res);
          this.products.splice(this.index,1, res.data);        
        })
        .catch(err => {
          console.log(err);
        })
        .then(() => {
          this.loading = false;
        })
    },  
    deleteProduct(id) {
      this.loading = true;
      axios.delete('/Admin/products/' + id)
        .then(res => {
          console.log(res);
          this.products.splice(this.index,1);
        })
        .catch(err => {
          console.log(err);
        })
        .then(() => {
          this.loading = false;
        })
    },  
  }
  
}

Vue.createApp(Component).mount('#app')