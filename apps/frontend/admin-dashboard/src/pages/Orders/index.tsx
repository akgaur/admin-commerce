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
} from '@mui/material';
import {
  Visibility as ViewIcon,
  LocalShipping as ShipIcon,
} from '@mui/icons-material';

interface Order {
  id: string;
  orderNumber: string;
  customer: string;
  date: string;
  total: number;
  status: 'pending' | 'processing' | 'shipped' | 'delivered' | 'cancelled';
}

const getStatusColor = (status: Order['status']): 'warning' | 'info' | 'primary' | 'success' | 'error' => {
  const colors = {
    pending: 'warning',
    processing: 'info',
    shipped: 'primary',
    delivered: 'success',
    cancelled: 'error',
  } as const;
  return colors[status];
};

export default function Orders() {
  const [orders, setOrders] = useState<Order[]>([]);

  useEffect(() => {
    // TODO: Fetch real data from API
    setOrders([
      {
        id: '1',
        orderNumber: 'ORD-001',
        customer: 'John Doe',
        date: '2025-01-23',
        total: 299.99,
        status: 'pending',
      },
      {
        id: '2',
        orderNumber: 'ORD-002',
        customer: 'Jane Smith',
        date: '2025-01-22',
        total: 149.99,
        status: 'processing',
      },
      {
        id: '3',
        orderNumber: 'ORD-003',
        customer: 'Bob Johnson',
        date: '2025-01-21',
        total: 499.99,
        status: 'shipped',
      },
    ]);
  }, []);

  const handleView = (id: string) => {
    // TODO: Implement view functionality
    console.log('View order:', id);
  };

  const handleShip = (id: string) => {
    // TODO: Implement shipping functionality
    console.log('Ship order:', id);
  };

  return (
    <Box>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Orders
      </Typography>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Order Number</TableCell>
              <TableCell>Customer</TableCell>
              <TableCell>Date</TableCell>
              <TableCell align="right">Total</TableCell>
              <TableCell>Status</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {orders.map((order) => (
              <TableRow key={order.id}>
                <TableCell>{order.orderNumber}</TableCell>
                <TableCell>{order.customer}</TableCell>
                <TableCell>{order.date}</TableCell>
                <TableCell align="right">
                  ${order.total.toFixed(2)}
                </TableCell>
                <TableCell>
                  <Chip
                    label={order.status}
                    color={getStatusColor(order.status)}
                    size="small"
                  />
                </TableCell>
                <TableCell align="right">
                  <IconButton
                    size="small"
                    onClick={() => handleView(order.id)}
                  >
                    <ViewIcon />
                  </IconButton>
                  {order.status === 'processing' && (
                    <IconButton
                      size="small"
                      onClick={() => handleShip(order.id)}
                    >
                      <ShipIcon />
                    </IconButton>
                  )}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}
