import { useState, useEffect } from 'react';
import {
  Box,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  IconButton,
  Chip,
  TextField,
  InputAdornment,
} from '@mui/material';
import {
  Visibility as ViewIcon,
  Edit as EditIcon,
  Search as SearchIcon,
} from '@mui/icons-material';

interface Customer {
  id: string;
  name: string;
  email: string;
  joinDate: string;
  ordersCount: number;
  totalSpent: number;
  status: 'active' | 'inactive';
}

export default function Customers() {
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    // TODO: Fetch real data from API
    setCustomers([
      {
        id: '1',
        name: 'John Doe',
        email: 'john.doe@example.com',
        joinDate: '2024-12-01',
        ordersCount: 5,
        totalSpent: 749.95,
        status: 'active',
      },
      {
        id: '2',
        name: 'Jane Smith',
        email: 'jane.smith@example.com',
        joinDate: '2024-12-15',
        ordersCount: 3,
        totalSpent: 299.97,
        status: 'active',
      },
      {
        id: '3',
        name: 'Bob Johnson',
        email: 'bob.johnson@example.com',
        joinDate: '2025-01-01',
        ordersCount: 1,
        totalSpent: 99.99,
        status: 'inactive',
      },
    ]);
  }, []);

  const filteredCustomers = customers.filter(
    (customer) =>
      customer.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      customer.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleView = (id: string) => {
    // TODO: Implement view functionality
    console.log('View customer:', id);
  };

  const handleEdit = (id: string) => {
    // TODO: Implement edit functionality
    console.log('Edit customer:', id);
  };

  return (
    <Box>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Customers
      </Typography>

      <Box sx={{ mb: 3 }}>
        <TextField
          fullWidth
          variant="outlined"
          placeholder="Search customers..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
        />
      </Box>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Join Date</TableCell>
              <TableCell align="right">Orders</TableCell>
              <TableCell align="right">Total Spent</TableCell>
              <TableCell>Status</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {filteredCustomers.map((customer) => (
              <TableRow key={customer.id}>
                <TableCell>{customer.name}</TableCell>
                <TableCell>{customer.email}</TableCell>
                <TableCell>{customer.joinDate}</TableCell>
                <TableCell align="right">{customer.ordersCount}</TableCell>
                <TableCell align="right">
                  ${customer.totalSpent.toFixed(2)}
                </TableCell>
                <TableCell>
                  <Chip
                    label={customer.status}
                    color={customer.status === 'active' ? 'success' : 'default'}
                    size="small"
                  />
                </TableCell>
                <TableCell align="right">
                  <IconButton
                    size="small"
                    onClick={() => handleView(customer.id)}
                  >
                    <ViewIcon />
                  </IconButton>
                  <IconButton
                    size="small"
                    onClick={() => handleEdit(customer.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}
